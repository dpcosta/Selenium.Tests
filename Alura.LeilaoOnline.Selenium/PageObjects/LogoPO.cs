using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;

namespace Alura.LeilaoOnline.Selenium.PageObjects
{
    public class LogoPO
    {
        private readonly IWebDriver driver;

        //locators
        private readonly By logo;

        public LogoPO(IWebDriver webDriver)
        {
            driver = webDriver;
            logo = By.ClassName("brand-logo");
        }

        public HomePO VaiPraHome()
        {
            driver.FindElement(logo).Click();
            return new HomePO(driver);
        }
    }
}
