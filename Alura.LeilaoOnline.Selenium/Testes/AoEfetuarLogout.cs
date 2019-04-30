using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using OpenQA.Selenium;
using Alura.LeilaoOnline.Selenium.PageObjects;
using Alura.LeilaoOnline.Selenium.Helpers;
using OpenQA.Selenium.Chrome;
using Alura.LeilaoOnline.Selenium.Fixtures;

namespace Alura.LeilaoOnline.Selenium.Testes
{
    [Collection("Chrome Driver")]
    [Trait("Tipo", "UI")]
    public class AoEfetuarLogout
    {
        private IWebDriver driver;

        public AoEfetuarLogout(WebDriverFixture fixture)
        {
            driver = fixture.Driver;
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        }

        [Fact(Skip = "Temporariamente desabilitado")]
        public void NaPaginaDeDashboardDeveLevarParaHomeNaoLogada()
        {
            //arrange
            driver.Navigate().GoToUrl(TestHelper.UrlDoSistema);

            var loginPage = new LoginPO(driver);
            loginPage.PreencheFormLogin("fulano@example.org", "123");
            var dashboard = loginPage.SubmeteFormEsperandoSucesso();

            //act
            dashboard.Menu.EfetuaLogout();

            //assert
            Assert.Contains("Login", driver.PageSource);
        }
    }
}
