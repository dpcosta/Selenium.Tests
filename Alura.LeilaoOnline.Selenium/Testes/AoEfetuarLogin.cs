using System;
using Xunit;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Alura.LeilaoOnline.Selenium.Helpers;
using Alura.LeilaoOnline.Selenium.PageObjects;

namespace Alura.LeilaoOnline.Selenium.Testes
{
    [Trait("Tipo", "UI")]
    public class AoEfetuarLogin : IDisposable
    {
        private IWebDriver driver;

        public AoEfetuarLogin()
        {
            driver = new ChromeDriver(TestHelper.PastaDoExecutavel);
        }

        public void Dispose()
        {
            driver.Quit();
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
