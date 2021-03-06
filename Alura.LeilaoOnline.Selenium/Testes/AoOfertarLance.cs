﻿using System;
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
    public class AoOfertarLance
    {
        private IWebDriver driver;

        public AoOfertarLance(WebDriverFixture fixture)
        {
            driver = fixture.Driver;
        }

        [Fact]
        public void DadaOfertaDeLanceValidaDeveAtualizarLanceAtual()
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

            //act: quando um lance é ofertado com sucesso
            detalheLeilaoPO.OfertaLanceBemSucedido(lanceOfertado);

            //assert: então o novo lance deve ser exibido como atual
            Assert.Equal(lanceOfertado, detalheLeilaoPO.LanceAtual);

        }

    }
}
