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
    public class AoOfertarLance : IDisposable
    {
        private IWebDriver driver;

        public AoOfertarLance()
        {
            driver = new ChromeDriver(TestHelper.PastaDoExecutavel);
        }

        public void Dispose()
        {
            driver.Quit();
        }

        [Fact]
        public void DadaOfertaDeLanceValidaDeveExibirLanceNoDashboard()
        {
            //arrange: dados
            //- usuário logado, 
            //- leilão id 1 possui status PregaoEmAndamento
            //- oferta válida
            double lanceOfertado = 1200;
            int idLeilao = 1;

            var detalheLeilaoPO = 
                LoginPO.EfetuaLoginBemSucedido(driver, "fulano@example.org", "123")
                .Menu.Logo.VaiPraHome()
                .ProximosLeiloes.VaiParaDetalheDoLeilao(idLeilao);

            //act
            detalheLeilaoPO.OfertaLanceBemSucedido(lanceOfertado);

            //assert
            double lanceExibido = detalheLeilaoPO
                .VaiProDashboard()
                .LancesOfertados
                .Select(l => l.Valor)
                .First();
            Assert.Equal(lanceOfertado, lanceExibido);

        }

    }
}
