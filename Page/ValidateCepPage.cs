using TestesAutomatizados.Core;

namespace TestesAutomatizados.Page
{
    public class ValidateCepPage : Begin
    {
        public void EnterZipCode()
        {
            WriteText("//*[@id='endereco']", "15606160");
        }

        public void ClickBtnZipCode()
        {
            ClickElement("//*[@id='btn_pesquisar']");
        }

        public void ValidadeResult()
        {
            ValidateData("//*[@id='resultado-DNEC']//tr[1]/td[1]", "Rua Rio Grande do Norte - lado ímpar");
        }

        public void ValidadeResultTotal()
        {
            string[] data = {
                "Rua Rio Grande do Norte - lado ímpar",
                "Brasilândia",
                "Fernandópolis/SP",
                "15606-160"
            };
            for (int i = 0; i < data.Length; i++)
            {
                ValidateData($"//*[@id='resultado-DNEC']//tr/td[{i + 1}]", data[i]);
                Console.WriteLine("Dados: " + data[i]);
            }
        }
    }
}
