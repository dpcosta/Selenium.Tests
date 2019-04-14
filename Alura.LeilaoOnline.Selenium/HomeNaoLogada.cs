using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Alura.LeilaoOnline.Selenium
{
    [Trait("Tipo", "UI")]
    public class HomeNaoLogada
    {
        [Fact]
        public void DeveTerOpcaoDeRegistroParaInteressadosNoLeilao()
        {
            //arrange
            IWebDriver driver = new FirefoxDriver(TestHelper.PastaDoExecutavel);

            //act
            driver.Navigate().GoToUrl(TestHelper.UrlDoSistema);

            //assert
            Assert.Contains("section-registro", driver.PageSource);

            driver.Quit();
        }
    }
}
