using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Alura.LeilaoOnline.Core;

namespace Alura.LeilaoOnline.Selenium.PageObjects
{
    public class ProximosLeiloesNaoLogadoPageObject
    {
        private readonly IWebDriver driver;
        private By linkDetalheLeilao;
        private By listaDeLeiloes;

        public ProximosLeiloesNaoLogadoPageObject(IWebDriver webDriver)
        {
            driver = webDriver;
            linkDetalheLeilao = By.LinkText("DETALHES");
            listaDeLeiloes = By.CssSelector(".section-prox-leiloes .card");
        }

        public IEnumerable<Leilao> Leiloes
        {
            get
            {
                var lista = new List<Leilao>();
                var elementos = driver.FindElements(listaDeLeiloes);
                foreach(var elemento in elementos)
                {
                    var titulo = elemento.FindElement(By.CssSelector(".card-title")).Text;
                    var imagem = elemento.FindElement(By.CssSelector(".card-image img")).GetAttribute("src");
                    var id = elemento.GetAttribute("data-id");
                    var leilao = new Leilao(titulo, null);
                    leilao.Imagem = imagem;
                    leilao.Id = Convert.ToInt32(id);
                    lista.Add(leilao);
                }
                return lista;
            }
        }

        public DetalheLeilaoPageObject VaiParaDetalheDoPrimeiroLeilao()
        {
            //vai pegar o primeiro elemento encontrado!
            driver.FindElement(linkDetalheLeilao).Click();
            return new DetalheLeilaoPageObject(driver);
        }

    }
}
