using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;

namespace Alura.LeilaoOnline.Selenium.PageObjects
{
    public class AgradecimentoPO
    {
        private readonly IWebDriver driver;

        public AgradecimentoPO(IWebDriver webDriver)
        {
            driver = webDriver;
        }

        public bool TextoAgradecimentoExiste => driver.PageSource.Contains("Obrigado", StringComparison.InvariantCultureIgnoreCase);
    }
}
