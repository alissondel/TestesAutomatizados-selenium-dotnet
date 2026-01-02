using TestesAutomatizados.Page;

namespace TestesAutomatizados.Test
{
    public class ValidateCepTest : ValidateCepPage
    {
        [Test]
        public void ValidateCep()
        {
            EnterZipCode();
            ClickBtnZipCode();
            //ValidadeResult();
            ValidadeResultTotal();
        }
    }
}
