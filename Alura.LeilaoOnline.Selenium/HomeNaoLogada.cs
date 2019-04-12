using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Alura.LeilaoOnline.Selenium
{
    public class HomeNaoLogada
    {
        [Fact]
        public void DeveTerOpcaoDeRegistroParaInteressadosNoLeilao()
        {
            //arrange
            IWebDriver driver = new ChromeDriver(DirectoryHelper.PastaDoExecutavel);

            //act
            driver.Navigate().GoToUrl("http://localhost:51128");

            //assert
            Assert.Contains("Registro", driver.PageSource);

            driver.Quit();
        }
    }
}
