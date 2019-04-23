using System;
using System.Collections.Generic;
using Alura.LeilaoOnline.Core;
using OpenQA.Selenium;

namespace Alura.LeilaoOnline.Selenium.PageObjects
{
    public class DashboardInteressadaPO
    {
        private readonly IWebDriver driver;

        //locators do dashboard
        private readonly By tabelaMinhasOfertas;

        //propriedades
        public MenuInteressadaPO Menu { get; }

        public DashboardInteressadaPO(IWebDriver webDriver)
        {
            driver = webDriver;
            tabelaMinhasOfertas = By.CssSelector(".minhas-ofertas table");
            Menu = new MenuInteressadaPO(driver);
        }

        public IEnumerable<Lance> LancesOfertados
        {
            get
            {
                var lista = new List<Lance>();
                var tabelaLances = driver.FindElement(tabelaMinhasOfertas);
                var linhas = tabelaLances.FindElements(By.TagName("tr"));
                foreach (var lance in linhas)
                {
                    var colunas = lance.FindElements(By.TagName("td"));
                    var l = new Lance(Convert.ToDouble(colunas[1].Text));
                    lista.Add(l);
                }
                return lista;
            }
        }

        public bool EstaNoDashboard => driver.PageSource.Contains("dashboard", StringComparison.InvariantCultureIgnoreCase);
    }
}
