using System;
using Alura.LeilaoOnline.Selenium.Helpers;
using OpenQA.Selenium;

namespace Alura.LeilaoOnline.Selenium.PageObjects
{
    /// <summary>
    /// Representa a região com o formulário de login a partir do padrão Page Object.
    /// </summary>
    public class LoginPO
    {
        private readonly IWebDriver driver;
        public IWebElement Login { get; set; }
        public IWebElement Senha { get; set; }
        public IWebElement BotaoSubmit { get; set; }

        public LoginPO(IWebDriver webDriver)
        {
            driver = webDriver;
            driver.Navigate().GoToUrl(TestHelper.UrlDoSistema + "/Autenticacao/Login");
            Login = driver.FindElement(By.Id("Login"));
            Senha = driver.FindElement(By.Id("Password"));
            BotaoSubmit = driver.FindElement(By.Id("btnLogin"));
        }

        public void PreencheFormLogin(string login, string senha)
        {
            Login.SendKeys(login);
            Senha.SendKeys(senha);
        }

        public DashboardInteressadaPO SubmeteFormEsperandoSucesso()
        {
            BotaoSubmit.Submit();
            return new DashboardInteressadaPO(driver);
        }

        public bool EstaNaPaginaDeLogin => driver.Title.Contains("login", StringComparison.InvariantCultureIgnoreCase);

        public DashboardInteressadaPO EfetuaLoginBemSucedido(string login, string senha)
        {
            PreencheFormLogin(login, senha);
            return SubmeteFormEsperandoSucesso();
        }

        public bool EstaNoDashboardAdmin => driver.PageSource.Contains("dashboard", StringComparison.InvariantCultureIgnoreCase);

    }
}
