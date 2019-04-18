using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using OpenQA.Selenium;
using Alura.LeilaoOnline.Selenium.PageObjects;
using Alura.LeilaoOnline.Selenium.Helpers;
using OpenQA.Selenium.Chrome;

namespace Alura.LeilaoOnline.Selenium.Testes
{
    [Trait("Tipo", "UI")]
    public class AoEfetuarLogout : IDisposable
    {
        private readonly IWebDriver driver;

        public AoEfetuarLogout()
        {
            driver = new ChromeDriver(TestHelper.PastaDoExecutavel);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        }

        public void Dispose()
        {
            driver.Quit();
        }

        [Fact(Skip = "Temporariamente desabilitado")]
        public void NaPaginaDeDashboardDeveLevarParaHomeNaoLogada()
        {
            //arrange
            driver.Navigate().GoToUrl(TestHelper.UrlDoSistema);

            var loginPage = new LoginPageObject(driver);
            loginPage.PreencheFormLogin("fulano@example.org", "123");
            loginPage.SubmeteForm();

            var dash = new DashboardInteressadaPageObject(driver);

            //act
            dash.EfetuaLogout();

            //assert
            Assert.Contains("Login", driver.PageSource);
        }
    }
}
