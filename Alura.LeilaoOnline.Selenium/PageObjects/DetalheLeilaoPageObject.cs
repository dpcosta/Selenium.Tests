using Alura.LeilaoOnline.Core;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace Alura.LeilaoOnline.Selenium.PageObjects
{
    public class DetalheLeilaoPageObject
    {
        private readonly IWebDriver driver;
        private By byLeilao;
        private By imagemLeilao;
        private By tituloLeilao;
        private By descricaoLeilao;

        public DetalheLeilaoPageObject(IWebDriver webDriver)
        {
            driver = webDriver;
            byLeilao = By.ClassName("leilao");
            imagemLeilao = By.CssSelector(".imagens .card-image img");
            tituloLeilao = By.CssSelector(".info .card-title");
            descricaoLeilao = By.CssSelector(".info .card-content p");
        }

        public bool NaoExibeOpcaoDarLance => !driver.PageSource.Contains("btnDarLance");

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

    }
}
