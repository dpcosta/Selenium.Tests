using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace Alura.LeilaoOnline.Selenium.PageObjects
{
    public class RegistroPageObject
    {
        private readonly IWebDriver driver;
        public IWebElement Email { get; }
        public IWebElement Senha { get; }
        public IWebElement ConfirmacaoSenha { get; }
        public IWebElement BotaoRegistro { get; }

        public RegistroPageObject(IWebDriver webDriver)
        {
            driver = webDriver;
            Email = driver.FindElement(By.Id("Email"));
            Senha = driver.FindElement(By.Id("Password"));
            ConfirmacaoSenha = driver.FindElement(By.Id("ConfirmPassword"));
            BotaoRegistro = driver.FindElement(By.Id("btnRegistro"));
        }

        public void PreencheFormulario(string email, string senha, string confirmacao)
        {
            Email.SendKeys(email);
            Senha.SendKeys(senha);
            ConfirmacaoSenha.SendKeys(confirmacao);
        }

        public void SubmeterFormulario()
        {
            BotaoRegistro.Click();
        }

        public bool EstaNaPaginaDeAgradecimento => driver.PageSource.Contains("Obrigado");
        public bool ContinuaNaPaginaPrincipal => driver.PageSource.Contains("section-registro");
    }
}
