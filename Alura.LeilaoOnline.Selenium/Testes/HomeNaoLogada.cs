using System;
using Xunit;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Alura.LeilaoOnline.Selenium.Helpers;
using Alura.LeilaoOnline.Selenium.Fixtures;

namespace Alura.LeilaoOnline.Selenium.Testes
{
    [Collection("Chrome Driver")]
    [Trait("Tipo", "UI")]
    public class HomeNaoLogada
    {

        private IWebDriver driver;

        public HomeNaoLogada(WebDriverFixture fixture)
        {
            driver = fixture.Driver;
        }

        [Fact]
        public void DeveTerOpcaoDeRegistroParaInteressadosNoLeilao()
        {
            //arrange
            //IWebDriver driver = new ChromeDriver(TestHelper.PastaDoExecutavel);

            //act
            driver.Navigate().GoToUrl(TestHelper.UrlDoSistema);

            //assert
            Assert.Contains("section-registro", driver.PageSource);

        }

    }
}
