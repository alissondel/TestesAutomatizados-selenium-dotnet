using OpenQA.Selenium;

namespace TestesAutomatizados.Core
{
    public  class GlobalVariables
    {
        // DEFINE 'DRIVER' COMO GATILHO PARA OS WEBELEMENTS NOS TESTES AUTOMATIZADOS DO SELENIUM
        public required IWebDriver driver;

        // DEFINE FECHAR NAVEGADOR AO FINAL DE TESTE COMO PADRÃO
        public bool driverQuit = true;

        // HABILITA OU DESABILITADA MODO HEADLESS NOS TESTES AUTOMATIZADOS
        public bool headlessTest = false;
    }
}
