using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Xunit;
using Alura.LeilaoOnline.Selenium.Helpers;
using Alura.LeilaoOnline.Selenium.PageObjects;
using System.Linq;
using Alura.LeilaoOnline.Selenium.Fixtures;

namespace Alura.LeilaoOnline.Selenium.Testes
{
    [Collection("Chrome Driver")]
    [Trait("Tipo", "UI")]
    public class AoExibirDetalhesLeilao
    {
        private IWebDriver driver;

        public AoExibirDetalhesLeilao(WebDriverFixture fixture)
        {
            driver = fixture.Driver;
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
        public void DadaInfoLeilaoNaListaDeveExibirMesmasInfoNoDetalhe()
        {
            //arrange
            var proximosLeiloesPO = new HomePO(driver).ProximosLeiloes;
            var primeiroLeilaoExibido = proximosLeiloesPO.Leiloes.First();

            //act
            var detalhePO = proximosLeiloesPO.VaiParaDetalheDoPrimeiroLeilao();

            //assert
            var leilaoDetalhe = detalhePO.Leilao;
            Assert.Equal(primeiroLeilaoExibido.Id, leilaoDetalhe.Id);
            Assert.Equal(primeiroLeilaoExibido.Titulo, leilaoDetalhe.Titulo);
            Assert.Equal(primeiroLeilaoExibido.Imagem, leilaoDetalhe.Imagem);
        }

        [Fact]
        public void DadoUsuarioLogadoEPregaoNaoIniciadoNaoDeveExibirOpcaoDeDarLance()
        {
            //arrange: dado que usuário está logado E que leilão cujo Id é 3 possui status LeilaoAntesDoPregao:
            LoginPO.EfetuaLoginBemSucedido(driver,"fulano@example.org", "123");
            var idLeilao = 3;

            //act: ao exibir os detalhes do leilão
            var detalhePO = new DetalheLeilaoPO(driver, idLeilao);

            //assert: então não deve exibir a opção de dar lances
            Assert.True(detalhePO.NaoExibeOpcaoDarLance);
        }

        [Fact]
        public void DadoUsuarioLogadoEPregaoEmAndamentoDeveExibirOpcaoDeDarLance()
        {
            //arrange: dado que usuário está logado E que leilão cujo Id é 1 possui status PregaoEmAndamento:
            LoginPO.EfetuaLoginBemSucedido(driver, "fulano@example.org", "123");
            var idLeilao = 1;

            //act: ao exibir os detalhes do leilão
            var detalhePO = new DetalheLeilaoPO(driver, idLeilao);

            //assert: então não deve exibir a opção de dar lances
            Assert.True(detalhePO.ExisteOpcaoDarLance);
        }

        
    }
}
