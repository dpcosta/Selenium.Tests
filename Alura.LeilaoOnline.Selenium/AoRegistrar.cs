using Alura.LeilaoOnline.Selenium.PageObjects;
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

            RegistroPageObject registroPO = new RegistroPageObject(driver);
            registroPO.PreencheFormulario("fulano@example.org", "123", "123");

            //act - ao registrar: clique do botão
            registroPO.SubmeterFormulario();

            //assert
            Assert.True(registroPO.EstaNaPaginaDeAgradecimento);
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
            RegistroPageObject registroPO = new RegistroPageObject(driver);
            registroPO.PreencheFormulario(email, senha, confirmacaoSenha);

            //act - ao registrar: clique do botão
            registroPO.SubmeterFormulario();

            //assert
            Assert.True(registroPO.ContinuaNaPaginaPrincipal);
        }
    }
}
