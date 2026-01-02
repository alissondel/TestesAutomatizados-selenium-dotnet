using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace TestesAutomatizados.Core
{
    public class DSL : GlobalVariables
    {
        #region Funções de Manipulação
        // Método para aguardar carregamento da pagina (Metodo com lambda expression)
        public static void Wait(int time) => Thread.Sleep(time); // Time em milissegundos

        // Metodo para limpar campo de input via XPath (Metodo com lambda expression)
        public void ClearField (string xpath) => driver.FindElement(By.XPath(xpath)).Clear();

        // Metodo que clica fora de um elemento (Metodo com lambda expression)
        public void ClickOut() => driver.FindElement(By.XPath("//html")).Click();

        // Metodo que espera o elemento surja na tela via XPath
        public void WaitElement(string element, int seconds = 90)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(seconds));
            wait.Until(d => d.FindElement(By.XPath(element)));
        }

        // Metodo que espera o elemento sumir da tela via XPath
        public void WaitElementGone(string element)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(90));
            wait.Until(d => d.FindElements(By.XPath(element)).Count == 0);
        }

        // Método para validar se o elemento existe na pagina via XPath
        public bool ValidateElementExists(string xpath)
        {
            try
            {
                driver.FindElement(By.XPath(xpath));
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        #endregion

        #region Funções de Interação

        // Método para interagir com input da pagina inserindo valor no campo via XPath
        public void WriteText (string xpath, string value)
        {
            driver.FindElement(By.XPath(xpath)).SendKeys(value);
        }

        // Método para interagir dando clique no botão pegando valor via XPath
        public void ClickElement (string element)
        {
            driver.FindElement(By.XPath(element)).Click();
        }

        #endregion

        // Método para validar se o valor esperado está presente na tela via XPath
        public void ValidateData(string xpath, string value)
        {
            // O site do correio possui um recaptcha e que atrapalha o teste, por isso foi necessário implementar o WebDriverWait para aguardar o carregamento do elemento antes da validação
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));

            wait.Until(d =>
                d.FindElement(By.XPath(xpath)).Text.Contains(value)
            );

            Assert.That(
                driver.FindElement(By.XPath(xpath)).Text,
                Does.Contain(value)
            );
            //Assert.That(driver.FindElement(By.XPath(xpath)).Text, Does.Contain(value));
        }
    }
}
