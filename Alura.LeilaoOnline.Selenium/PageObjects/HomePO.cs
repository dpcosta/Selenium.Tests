using Alura.LeilaoOnline.Selenium.Helpers;
using OpenQA.Selenium;

namespace Alura.LeilaoOnline.Selenium.PageObjects
{
    public class HomePO
    {
        private readonly IWebDriver driver;

        //partes visíveis da página
        public ProximosLeiloesPO ProximosLeiloes { get; }
        //public CategoriasLeilaoPO Categorias { get; }
        public RegistroPO Registro { get; }

        public HomePO(IWebDriver webDriver)
        {
            driver = webDriver;
            driver.Navigate().GoToUrl(TestHelper.UrlDoSistema);
            ProximosLeiloes = new ProximosLeiloesPO(driver);
            Registro = new RegistroPO(driver);
        }
    }
}