using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Alura.LeilaoOnline.Selenium
{
    [Trait("Tipo", "UI")]
    public class AoRegistrar : IDisposable
    {
        private readonly IWebDriver driver;

        public AoRegistrar()
        {
            driver = new ChromeDriver(TestHelper.PastaDoExecutavel);
        }

        public void Dispose()
        {
            driver.Quit();
        }

        [Fact]
        public void DadasInfoValidasDeveLevarParaPaginaAgradecimento()
        {
            //arrange - info válidas
            driver.Navigate().GoToUrl(TestHelper.UrlDoSistema);
            IWebElement campoEmail = driver.FindElement(By.Id("Email"));
            IWebElement campoSenha = driver.FindElement(By.Id("Password"));
            IWebElement campoConfirmacaoSenha = driver.FindElement(By.Id("ConfirmPassword"));
            IWebElement botaoRegistro = driver.FindElement(By.Id("btnRegistro"));

            campoEmail.SendKeys("fulano@example.org");
            campoSenha.SendKeys("123");
            campoConfirmacaoSenha.SendKeys("123");

            //act - ao registrar: clique do botão
            botaoRegistro.Click();

            //assert
            Assert.Contains("Obrigado", driver.PageSource);
        }

        [Theory]
        [InlineData("fulano@example.org", "123", "456")]
        [InlineData("fulano", "123", "123")]
        [InlineData("", "123", "123")]
        public void DadasInfoInvalidasDeveContinuarNaHome(
            string email, 
            string senha, 
            string confirmacaoSenha)
        {
            //arrange - info válidas
            driver.Navigate().GoToUrl(TestHelper.UrlDoSistema);
            IWebElement campoEmail = driver.FindElement(By.Id("Email"));
            IWebElement campoSenha = driver.FindElement(By.Id("Password"));
            IWebElement campoConfirmacaoSenha = driver.FindElement(By.Id("ConfirmPassword"));
            IWebElement botaoRegistro = driver.FindElement(By.Id("btnRegistro"));

            campoEmail.SendKeys(email);
            campoSenha.SendKeys(senha);
            campoConfirmacaoSenha.SendKeys(confirmacaoSenha);

            //act - ao registrar: clique do botão
            botaoRegistro.Click();

            //assert
            Assert.Contains("section-registro", driver.PageSource);
        }
    }
}
