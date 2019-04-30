using Xunit;
using OpenQA.Selenium;
using Alura.LeilaoOnline.Selenium.PageObjects;
using Alura.LeilaoOnline.Selenium.Fixtures;

namespace Alura.LeilaoOnline.Selenium.Testes
{
    [Collection("Chrome Driver")]
    [Trait("Tipo", "UI")]
    public class AoEfetuarLogin
    {
        private IWebDriver driver;

        public AoEfetuarLogin(WebDriverFixture fixture)
        {
            driver = fixture.Driver;
        }

        [Fact]
        public void DadaInfoValidaDeveRedirecionarParaDashboard()
        {
            //arrange
            var loginPage = new LoginPO(driver);
            //IMPORTANTE: depende de dados de uma base 'inicial'!
            loginPage.PreencheFormLogin("fulano@example.org", "123");

            //act
            var dashboard = loginPage.SubmeteFormEsperandoSucesso();

            //assert
            Assert.True(dashboard.EstaNoDashboard);
        }
    }
}
