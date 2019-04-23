using System;
using Alura.LeilaoOnline.Selenium.Helpers;
using OpenQA.Selenium;

namespace Alura.LeilaoOnline.Selenium.PageObjects
{
    public class LoginPO
    {
        private readonly IWebDriver driver;

        //locators
        private readonly By inputLogin;
        private readonly By inputSenha;
        private readonly By botaoSubmit;

        public LoginPO(IWebDriver webDriver)
        {
            driver = webDriver;
            driver.Navigate().GoToUrl(TestHelper.UrlDoSistema + "/Autenticacao/Login");
            inputLogin = By.Id("Login");
            inputSenha = By.Id("Password");
            botaoSubmit = By.Id("btnLogin");
        }

        public LoginPO PreencheFormLogin(string login, string senha)
        {
            driver.FindElement(inputLogin).SendKeys(login);
            driver.FindElement(inputSenha).SendKeys(senha);
            return this;
        }

        public DashboardInteressadaPO SubmeteFormEsperandoSucesso()
        {
            driver.FindElement(botaoSubmit).Submit();
            return new DashboardInteressadaPO(driver);
        }

        public bool EstaNaPaginaDeLogin => driver.Title.Contains("login", StringComparison.InvariantCultureIgnoreCase);

        public static DashboardInteressadaPO EfetuaLoginBemSucedido(IWebDriver driver, string login, string senha)
        {
            return new LoginPO(driver)
                .PreencheFormLogin(login, senha)
                .SubmeteFormEsperandoSucesso();
        }

    }
}
