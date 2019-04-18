using OpenQA.Selenium;

namespace Alura.LeilaoOnline.Selenium.PageObjects
{
    public class HomePO
    {
        private readonly IWebDriver driver;

        public HomePO(IWebDriver webDriver)
        {
            driver = webDriver;
        }

        public ProximosLeiloesPO ProximosLeiloes => new ProximosLeiloesPO(driver);
    }
}