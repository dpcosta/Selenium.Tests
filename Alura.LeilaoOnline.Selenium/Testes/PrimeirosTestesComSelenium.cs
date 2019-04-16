using System;
using System.Collections.Generic;
using Xunit;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using Alura.LeilaoOnline.Selenium.Helpers;

namespace Alura.LeilaoOnline.Selenium.Testes
{
    [Trait("Tipo", "UI")]
    public class PrimeirosTestesComSelenium
    {
        [Fact(Skip = "Usado apenas para introdução do Selenium")]
        public void TituloDeveConterCaelumAoNavegarParaHomeCaelum()
        {
            //arrange
            IWebDriver driver = new ChromeDriver(TestHelper.PastaDoExecutavel);
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
                new object[] { new ChromeDriver(TestHelper.PastaDoExecutavel) },
                new object[] { new FirefoxDriver(TestHelper.PastaDoExecutavel) },
            };

        [Fact(Skip = "Usado apenas para introdução do Selenium")]
        //[MemberData(nameof(CriaDriver))]
        public void PaginaDeveConterOpcaoDeContatoAoNavegarParaHomeCaelum()
        {
            //arrange
            IWebDriver driver = new ChromeDriver(TestHelper.PastaDoExecutavel);
            INavigation nav = driver.Navigate();
            //act
            nav.GoToUrl("https://www.caelum.com.br");
            //assert
            Assert.Contains("Contato", driver.PageSource, StringComparison.InvariantCultureIgnoreCase);
            driver.Quit();
        }
    }
}
