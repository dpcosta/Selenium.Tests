using System;
using Alura.LeilaoOnline.Selenium.Helpers;
using OpenQA.Selenium;

namespace Alura.LeilaoOnline.Selenium.PageObjects
{
    /// <summary>
    /// Representa a região com o formulário de login a partir do padrão Page Object.
    /// </summary>
    public class LoginPageObject
    {
        private readonly IWebDriver driver;
        public IWebElement Login { get; set; }
        public IWebElement Senha { get; set; }
        public IWebElement BotaoSubmit { get; set; }

        public LoginPageObject(IWebDriver webDriver)
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

        public void SubmeteForm()
        {
            BotaoSubmit.Submit();
        }

        public bool EstaNaPaginaDeLogin => driver.Title.Contains("login", StringComparison.InvariantCultureIgnoreCase);

        public bool EstaNoDashboardInteressada => driver.PageSource.Contains("dashboard", StringComparison.InvariantCultureIgnoreCase);

        public bool EstaNoDashboardAdmin => driver.PageSource.Contains("dashboard", StringComparison.InvariantCultureIgnoreCase);

    }
}
