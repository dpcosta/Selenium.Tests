using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Alura.LeilaoOnline.Selenium.Helpers
{
    public static class WebDriverExtensions
    {
        public static bool ElementIsVisible(this IWebDriver driver, By locator, int timeoutInSeconds = 3)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
            try
            {
                var element = wait.Until(drv => drv.FindElement(locator));
                return element.Displayed;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
