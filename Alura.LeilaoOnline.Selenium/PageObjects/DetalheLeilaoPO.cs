using Alura.LeilaoOnline.Core;
using Alura.LeilaoOnline.Selenium.Helpers;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace Alura.LeilaoOnline.Selenium.PageObjects
{
    public class DetalheLeilaoPO
    {
        private readonly IWebDriver driver;

        //locators
        private readonly By byLeilao;
        private readonly By imagemLeilao;
        private readonly By tituloLeilao;
        private readonly By descricaoLeilao;
        private readonly By campoLance;
        private readonly By btnDarLance;
        private readonly By submeteLance;

        public DetalheLeilaoPO(IWebDriver webDriver)
        {
            driver = webDriver;
            byLeilao = By.ClassName("leilao");
            imagemLeilao = By.CssSelector(".imagens .card-image img");
            tituloLeilao = By.CssSelector(".info .card-title");
            descricaoLeilao = By.CssSelector(".info .card-content p");
            campoLance = By.Id("Valor");
            btnDarLance = By.Id("btnDarLance");
            submeteLance = By.Id("modalLance");
        }

        public DetalheLeilaoPO(IWebDriver webDriver, int idLeilao) : this(webDriver)
        {
            driver.Navigate().GoToUrl(TestHelper.UrlDoSistema + $"/Home/Detalhes/{idLeilao}");
        }

        public bool NaoExibeOpcaoDarLance => !ExisteOpcaoDarLance;
        public bool ExisteOpcaoDarLance => driver.ElementIsVisible(btnDarLance);
        

        public Leilao Leilao
        {
            get
            {
                var elementoLeilao = driver.FindElement(byLeilao);
                var titulo = elementoLeilao.FindElement(tituloLeilao).Text;
                var leilao = new Leilao(titulo, null);
                leilao.Id = Convert.ToInt32(elementoLeilao.GetAttribute("data-id"));
                leilao.Imagem = elementoLeilao.FindElement(imagemLeilao).GetAttribute("src");
                leilao.Descricao = elementoLeilao.FindElement(descricaoLeilao).Text;
                return leilao;
            }
        }

        public DetalheLeilaoPO OfertaLanceBemSucedido(double valor)
        {
            //mostrar modal
            driver.FindElement(btnDarLance).Click();

            //preencher valor do lance
            driver.FindElement(campoLance).SendKeys(valor.ToString());

            //submeter o lance 
            driver.FindElement(submeteLance).Submit();

            return this;
        }

        public DashboardInteressadaPO VaiProDashboard()
        {
            //não há ctz se está logado e se está logado como interessada
            var menuLogado = new MenuInteressadaPO(driver);
            return menuLogado.VaiProDashboard();
        }

    }
}
