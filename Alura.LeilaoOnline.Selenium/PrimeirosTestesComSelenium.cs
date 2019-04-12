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
        private static readonly string nomePasta = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

        [Fact]
        public void TituloDeveConterCaelumAoNavegarParaHomeCaelum()
        {
            //arrange
            IWebDriver driver = new ChromeDriver(nomePasta);
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
                new object[] { new ChromeDriver(nomePasta) },
                new object[] { new FirefoxDriver(nomePasta) },
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
