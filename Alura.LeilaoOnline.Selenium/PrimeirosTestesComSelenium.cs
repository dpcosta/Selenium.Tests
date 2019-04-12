using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Xunit;

namespace Alura.LeilaoOnline.Selenium
{
    public class PrimeirosTestesComSelenium
    {
        [Fact]
        public void TituloDeveConterCaelumAoNavegarParaHomeCaelum()
        {
            //arrange
            IWebDriver driver = new ChromeDriver(DirectoryHelper.PastaDoExecutavel);
            INavigation nav = driver.Navigate();
            //act
            nav.GoToUrl("https://www.caelum.com.br");
            //assert
            Assert.Contains("Caelum", driver.Title);
            driver.Quit();
        }

        public static IEnumerable<object[]> CriaDriver =>
            new List<object[]>
            {
                new object[] { new ChromeDriver(DirectoryHelper.PastaDoExecutavel) },
                new object[] { new FirefoxDriver(DirectoryHelper.PastaDoExecutavel) },
            };

        [Theory]
        [MemberData(nameof(CriaDriver))]
        public void PaginaDeveConterOpcaoDeContatoAoNavegarParaHomeCaelum(IWebDriver driver)
        {
            //arrange
            INavigation nav = driver.Navigate();
            //act
            nav.GoToUrl("https://www.caelum.com.br");
            //assert
            Assert.Contains("Contato", driver.PageSource, StringComparison.InvariantCultureIgnoreCase);
            driver.Quit();
        }
    }
}
