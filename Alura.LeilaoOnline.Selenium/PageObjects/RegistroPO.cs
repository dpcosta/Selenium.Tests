using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace Alura.LeilaoOnline.Selenium.PageObjects
{
    public class RegistroPO
    {
        private readonly IWebDriver driver;
        public IWebElement Nome { get; set; }
        public IWebElement Email { get; }
        public IWebElement Senha { get; }
        public IWebElement ConfirmacaoSenha { get; }
        public IWebElement BotaoRegistro { get; }

        public RegistroPO(IWebDriver webDriver)
        {
            driver = webDriver;
            Nome = driver.FindElement(By.Id("Nome"));
            Email = driver.FindElement(By.Id("Email"));
            Senha = driver.FindElement(By.Id("Password"));
            ConfirmacaoSenha = driver.FindElement(By.Id("ConfirmPassword"));
            BotaoRegistro = driver.FindElement(By.Id("btnRegistro"));
        }

        public void PreencheFormulario(string nome, string email, string senha, string confirmacao)
        {
            Nome.SendKeys(nome);
            Email.SendKeys(email);
            Senha.SendKeys(senha);
            ConfirmacaoSenha.SendKeys(confirmacao);
        }

        public AgradecimentoPO SubmeterFormEsperandoSucesso()
        {
            BotaoRegistro.Click();
            return new AgradecimentoPO(driver);
        }

        public RegistroPO SubmeterFormularioEsperandoFracasso()
        {
            BotaoRegistro.Click();
            return this;
        }

        public bool ContinuaNaPaginaDeRegistro => driver.PageSource.Contains("section-registro", StringComparison.InvariantCultureIgnoreCase);
    }
}
