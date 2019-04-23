using System;
using Xunit;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Alura.LeilaoOnline.Selenium.PageObjects;
using Alura.LeilaoOnline.Selenium.Helpers;

namespace Alura.LeilaoOnline.Selenium.Testes
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
            var home = new HomePO(driver);
            home.Registro.PreencheFormulario("Fulano", "fulano@example.org", "123", "123");

            //act - ao registrar: clique do botão
            var agradecimentoPO = home.Registro.SubmeterFormEsperandoSucesso();

            //assert
            Assert.True(agradecimentoPO.TextoAgradecimentoExiste);
        }

        [Theory]
        [InlineData("Fulano", "fulano@example.org", "123", "456")]
        [InlineData("Fulano", "fulano", "123", "123")]
        [InlineData("Fulano", "", "123", "123")]
        [InlineData("", "fulano@example.org", "123", "123")]
        public void DadasInfoInvalidasDeveContinuarNaHome(
            string nome, 
            string email, 
            string senha, 
            string confirmacaoSenha)
        {
            //arrange - info válidas
            var home = new HomePO(driver);
            home.Registro.PreencheFormulario(nome, email, senha, confirmacaoSenha);

            //act - ao registrar: clique do botão
            var resultado = home.Registro.SubmeterFormularioEsperandoFracasso();

            //assert
            Assert.True(resultado.ContinuaNaPaginaDeRegistro);
        }
    }
}
