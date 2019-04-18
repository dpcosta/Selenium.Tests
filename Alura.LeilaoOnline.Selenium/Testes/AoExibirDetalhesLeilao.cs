using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Xunit;
using Alura.LeilaoOnline.Selenium.Helpers;
using Alura.LeilaoOnline.Selenium.PageObjects;
using System.Linq;

namespace Alura.LeilaoOnline.Selenium.Testes
{
    [Trait("Tipo", "UI")]
    public class AoExibirDetalhesLeilao : IDisposable
    {
        private IWebDriver driver;

        public AoExibirDetalhesLeilao()
        {
            driver = new ChromeDriver(TestHelper.PastaDoExecutavel);
        }

        public void Dispose()
        {
            driver.Quit();
        }

        [Fact]
        public void DadoUsuarioNaoLogadoNaoDeveExibirOpcaoDarLance()
        {
            //arrange
            driver.Navigate().GoToUrl(TestHelper.UrlDoSistema);
            var proximosLeiloesPO = new ProximosLeiloesPO(driver);

            //act
            var detalhePO = proximosLeiloesPO.VaiParaDetalheDoPrimeiroLeilao();

            //assert
            Assert.True(detalhePO.NaoExibeOpcaoDarLance);
        }

        [Fact]
        public void DadoUsuarioLogadoDevePermitirDarLance()
        {
            //arrange
            driver.Navigate().GoToUrl(TestHelper.UrlDoSistema);
            var loginPO = new LoginPO(driver);
            var dashbIntPO = loginPO.EfetuaLoginBemSucedido("fulano@example.org", "123");
            var homePO = dashbIntPO.VaiPraHome();
            var proximosLeiloesPO = homePO.ProximosLeiloes;

            //act
            var detalhePO = proximosLeiloesPO.VaiParaDetalheDoPrimeiroLeilao();

            //assert
            Assert.True(detalhePO.ExisteOpcaoDarLance);
        }

        [Fact]
        public void DadaInfoLeilaoNaListaDeveExibirMesmasInfoNoDetalhe()
        {
            //arrange
            driver.Navigate().GoToUrl(TestHelper.UrlDoSistema);
            var proximosLeiloesPO = new ProximosLeiloesPO(driver);
            var primeiroLeilaoExibido = proximosLeiloesPO.Leiloes.First();

            //act
            var detalhePO = proximosLeiloesPO.VaiParaDetalheDoPrimeiroLeilao();

            //assert
            var leilaoDetalhe = detalhePO.Leilao;
            Assert.Equal(primeiroLeilaoExibido.Id, leilaoDetalhe.Id);
            Assert.Equal(primeiroLeilaoExibido.Titulo, leilaoDetalhe.Titulo);
            Assert.Equal(primeiroLeilaoExibido.Imagem, leilaoDetalhe.Imagem);
        }
    }
}
