using OpenQA.Selenium.Chrome;

namespace TestesAutomatizados.Core
{
    public class Begin : DSL
    {
        #region Code Open Browser
        private void OpenBrowser()
        {
            // Modo headless para execução em segundo plano
            var headlessMode = new ChromeOptions();
            headlessMode.AddArgument("window-size=1366x768");
            headlessMode.AddArgument("disk-cache-size=0");
            headlessMode.AddArgument("headless");

            // Modo desenvolvedor para execução visível
            var devMode = new ChromeOptions();
            devMode.AddArgument("disk-cache-size=0");
            devMode.AddArgument("start-maximized");

            if (headlessTest)
            {
                driver = new ChromeDriver(headlessMode);
            }
            else
            {
                driver = new ChromeDriver(devMode);
                driverQuit = false;
            }   
            driver.Manage().Timeouts().ImplicitWait = System.TimeSpan.FromSeconds(5);
        }
        #endregion

        [SetUp]
        public void StartTest()
        {
            OpenBrowser();
            // driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://buscacepinter.correios.com.br/app/endereco/index.php");
            // driver.Manage().Window.Maximize();
            // driver.Manage().Timeouts().ImplicitWait = System.TimeSpan.FromSeconds(5);
            // driverQuit = false;
        }

        [TearDown]
        public void EndTest()
        {
            if(driverQuit) driver.Quit();
        }
    }
}
