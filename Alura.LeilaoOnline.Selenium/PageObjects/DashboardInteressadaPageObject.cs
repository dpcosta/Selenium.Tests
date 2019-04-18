using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace Alura.LeilaoOnline.Selenium.PageObjects
{
    public class DashboardInteressadaPageObject
    {
        private readonly IWebDriver driver;
        public By LinkMeuPerfil { get; set; }
        public By LinkLogout { get; set; }

        public DashboardInteressadaPageObject(IWebDriver webDriver)
        {
            driver = webDriver;
            LinkMeuPerfil = By.Id("meu-perfil");
            LinkLogout = By.LinkText("Logout");
        }

        public void EfetuaLogout()
        {
            Actions builder = new Actions(driver);
            var acao = builder
                .MoveToElement(driver.FindElement(LinkMeuPerfil))
                .MoveToElement(driver.FindElement(LinkLogout))
                .Click()
                .Build();
            acao.Perform();
            Thread.Sleep(6000);
        }
    }
}
