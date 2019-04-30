using Alura.LeilaoOnline.Selenium.Helpers;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

namespace Alura.LeilaoOnline.Selenium.Fixtures
{
    public sealed class WebDriverFixture : IDisposable
    {
        public IWebDriver Driver { get; private set; }

        public WebDriverFixture()
        {
            Driver = new ChromeDriver(TestHelper.PastaDoExecutavel);
            //executar script para criar o banco de testes
        }

        public void Dispose()
        {
            //executar script para dropar o banco de testes
            Driver.Quit();
        }
    }
}
