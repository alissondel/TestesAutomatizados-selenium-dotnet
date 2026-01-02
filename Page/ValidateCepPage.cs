using TestesAutomatizados.Core;

namespace TestesAutomatizados.Page
{
    public class ValidateCepPage : Begin
    {
        public void EnterZipCode()
        {
            WriteText("//*[@id='endereco']", "preencher_cep");
        }

        public void ClickBtnZipCode()
        {
            ClickElement("//*[@id='btn_pesquisar']");
        }

        public void ValidadeResult()
        {
            ValidateData("//*[@id='resultado-DNEC']//tr[1]/td[1]", "preencher_endereço");
        }

        public void ValidadeResultTotal()
        {
            string[] data = {
                "preencher_endereço",
                "preencher_bairro",
                "preencher_cidade/preencher_uf",
                "preencher_cep"
            };
            for (int i = 0; i < data.Length; i++)
            {
                ValidateData($"//*[@id='resultado-DNEC']//tr/td[{i + 1}]", data[i]);
                Console.WriteLine("Dados: " + data[i]);
            }
        }
    }
}
