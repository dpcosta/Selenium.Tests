using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace Alura.LeilaoOnline.Selenium.PageObjects
{
    public class MenuInteressadaPO
    {
        private readonly IWebDriver driver;

        //locators para os itens de menu
        private readonly By itemMenuDashboard;
        private readonly By itemMenuMeuPerfil;
        private readonly By itemMenuLogout;

        //propriedades para outros page objects
        public LogoPO Logo { get; }

        public MenuInteressadaPO(IWebDriver webDriver)
        {
            driver = webDriver;
            itemMenuDashboard = By.LinkText("Dashboard");
            itemMenuMeuPerfil = By.LinkText("Meu Perfil");
            itemMenuLogout = By.LinkText("Logout");
            Logo = new LogoPO(driver);
        }

        //métodos
        public DashboardInteressadaPO VaiProDashboard()
        {
            driver.FindElement(itemMenuDashboard).Click();
            return new DashboardInteressadaPO(driver);
        }

        public void EfetuaLogout()
        {
            Actions builder = new Actions(driver);
            var acao = builder
                .MoveToElement(driver.FindElement(itemMenuMeuPerfil))
                .MoveToElement(driver.FindElement(itemMenuLogout))
                .Click()
                .Build();
            acao.Perform();
            //Thread.Sleep(6000);
        }


    }
}
