using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using Alura.LeilaoOnline.Selenium.Helpers;
using Alura.LeilaoOnline.WebApp.Dados;
using Microsoft.EntityFrameworkCore;
using Alura.LeilaoOnline.Core;
using System.Collections.Generic;

namespace Alura.LeilaoOnline.Selenium.Fixtures
{
    public sealed class WebDriverFixture : IDisposable
    {
        public IWebDriver Driver { get; private set; }

        public WebDriverFixture()
        {
            Driver = new ChromeDriver(TestHelper.PastaDoExecutavel);
            //executar script para criar o banco de testes
            var dbContextOptions = new DbContextOptionsBuilder<LeiloesContext>()
                .UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=LeiloesDB;Trusted_Connection=true").Options;
            using (var ctx = new LeiloesContext(dbContextOptions))
            {
                //seed data

                //interessadas
                var fulano = new Interessada("Fulano de Tal") { Id = 1 };
                var maria
                    = new Interessada("Maria da Silva") { Id = 2 };

                //usuários
                var admin = new Usuario { Id = 1, Email = "admin@example.org", Senha = "123" };
                var usuFulano = new Usuario { Id = 2, Email = "fulano@example.org", Senha = "123", Interessada = fulano };
                var usuMaria = new Usuario { Id = 3, Email = "maria@example.org", Senha = "123", Interessada = maria };

                //leilões
                var leilaoArte1 = new Leilao("Leilão de Arte 1", null)
                {
                    Id = 1,
                    Descricao = "Lorem ipsum dolor sit amet consectetur adipisicing elit. Nisi quibusdam esse saepe doloribus culpa ratione enim? Praesentium quaerat libero iure animi distinctio temporibus necessitatibus error. Soluta ab natus quia iusto!",
                    Categoria = "Arte e Pintura",
                    Imagem = "/images/painting1.jpg",
                    ValorInicial = 859.99,
                    InicioPregao = DateTime.Now.AddDays(-2),
                    TerminoPregao = DateTime.Now.AddDays(2)
                };
                var leilaoArte2 = new Leilao("Leilão de Arte 2", null)
                {
                    Id = 2,
                    Descricao = "Lorem ipsum dolor sit amet consectetur adipisicing elit. Nisi quibusdam esse saepe doloribus culpa ratione enim? Praesentium quaerat libero iure animi distinctio temporibus necessitatibus error. Soluta ab natus quia iusto!",
                    Categoria = "Arte e Pintura",
                    Imagem = "/images/painting2.jpg",
                    ValorInicial = 935.78,
                    InicioPregao = DateTime.Now.AddDays(-1),
                    TerminoPregao = DateTime.Now.AddDays(3)
                };
                var leilaoArte3 = new Leilao("Leilão de Arte 3", null)
                {
                    Id = 3,
                    Descricao = "Lorem ipsum dolor sit amet consectetur adipisicing elit. Nisi quibusdam esse saepe doloribus culpa ratione enim? Praesentium quaerat libero iure animi distinctio temporibus necessitatibus error. Soluta ab natus quia iusto!",
                    Categoria = "Arte e Pintura",
                    Imagem = "/images/painting3.jpg",
                    ValorInicial = 57.90,
                    InicioPregao = DateTime.Now.AddDays(3),
                    TerminoPregao = DateTime.Now.AddDays(7),

                };
                var leilaoArte4 = new Leilao("Leilão de Arte 4", null)
                {
                    Id = 4,
                    Descricao =
                    "Lorem ipsum dolor sit amet consectetur adipisicing elit. Nisi quibusdam esse saepe doloribus culpa ratione enim? Praesentium quaerat libero iure animi distinctio temporibus necessitatibus error. Soluta ab natus quia iusto!",
                    Categoria = "Arte e Pintura",
                    Imagem = "/images/painting4.jpg",
                    ValorInicial = 120.0,
                    InicioPregao = DateTime.Now.AddDays(5),
                    TerminoPregao = DateTime.Now.AddDays(15)
                };
                var leilaoArte5 = new Leilao("Leilão de Arte 5", null)
                {
                    Id = 5,
                    Descricao = "Lorem ipsum dolor sit amet consectetur adipisicing elit. Nisi quibusdam esse saepe doloribus culpa ratione enim? Praesentium quaerat libero iure animi distinctio temporibus necessitatibus error. Soluta ab natus quia iusto!",
                    Categoria = "Arte e Pintura",
                    Imagem = "/images/painting5.jpg",
                    ValorInicial = 1500.0,
                    InicioPregao = DateTime.Now.AddDays(-5),
                    TerminoPregao = DateTime.Now.AddDays(-1),
                };


                var leilaoAuto1 = new Leilao("Leilão de Carro 1", null)
                {
                    Id = 6,
                    Descricao = "Lorem ipsum dolor sit amet consectetur adipisicing elit. Nisi quibusdam esse saepe doloribus culpa ratione enim? Praesentium quaerat libero iure animi distinctio temporibus necessitatibus error. Soluta ab natus quia iusto!",
                    Categoria = "Automóveis",
                    Imagem = "/images/carro1.jpg",
                    ValorInicial = 21000.0,
                    InicioPregao = DateTime.Now.AddDays(-2),
                    TerminoPregao = DateTime.Now.AddDays(2),
                };
                leilaoAuto1.IniciaPregao();

                var leilaoAuto2 = new Leilao("Leilão de Carro 2", null)
                {
                    Id = 7,
                    Descricao = "Lorem ipsum dolor sit amet consectetur adipisicing elit. Nisi quibusdam esse saepe doloribus culpa ratione enim? Praesentium quaerat libero iure animi distinctio temporibus necessitatibus error. Soluta ab natus quia iusto!",
                    Categoria = "Automóveis",
                    Imagem = "/images/carro2.jpg",
                    ValorInicial = 14500.0,
                    InicioPregao = DateTime.Now.AddDays(-1),
                    TerminoPregao = DateTime.Now.AddDays(3),

                };
                leilaoAuto2.IniciaPregao();

                var leilaoAuto3 = new Leilao("Leilão de Carro 3", null)
                {
                    Id = 8,
                    Descricao = "Lorem ipsum dolor sit amet consectetur adipisicing elit. Nisi quibusdam esse saepe doloribus culpa ratione enim? Praesentium quaerat libero iure animi distinctio temporibus necessitatibus error. Soluta ab natus quia iusto!",
                    Categoria = "Automóveis",
                    Imagem = "/images/carro3.jpg",
                    ValorInicial = 5890.0,
                    InicioPregao = DateTime.Now.AddDays(3),
                    TerminoPregao = DateTime.Now.AddDays(7),
                };

                var leilaoAuto4 = new Leilao("Leilão de Carro 4", null)
                {
                    Id = 9,
                    Descricao = "Lorem ipsum dolor sit amet consectetur adipisicing elit. Nisi quibusdam esse saepe doloribus culpa ratione enim? Praesentium quaerat libero iure animi distinctio temporibus necessitatibus error. Soluta ab natus quia iusto!",
                    Categoria = "Automóveis",
                    Imagem = "/images/carro4.jpg",
                    ValorInicial = 6700.0,
                    InicioPregao = DateTime.Now.AddDays(5),
                    TerminoPregao = DateTime.Now.AddDays(15),
                };

                var leilaoAuto5 = new Leilao("Leilão de Carro 5", null)
                {
                    Id = 10,
                    Descricao = "Lorem ipsum dolor sit amet consectetur adipisicing elit. Nisi quibusdam esse saepe doloribus culpa ratione enim? Praesentium quaerat libero iure animi distinctio temporibus necessitatibus error. Soluta ab natus quia iusto!",
                    Categoria = "Automóveis",
                    Imagem = "/images/carro5.jpg",
                    ValorInicial = 15900.0,
                    InicioPregao = DateTime.Now.AddDays(-5),
                    TerminoPregao = DateTime.Now.AddDays(-1),
                };
                leilaoAuto5.IniciaPregao();
                leilaoAuto5.TerminaPregao();

                leilaoArte1.IniciaPregao();
                leilaoArte2.IniciaPregao();
                leilaoArte5.IniciaPregao();
                leilaoArte5.TerminaPregao();

                var leiloes = new List<Leilao>
                {
                };

                //favoritos
                var favoritos = new List<Favorito>
                {

                };

                //lances
                var lances = new List<Lance>
                {

                };

                ctx.Leiloes.AddRange(
                    leilaoArte1,
                    leilaoArte2,
                    leilaoArte3,
                    leilaoArte4,
                    leilaoArte5
                );

                ctx.Usuarios.AddRange(admin, usuFulano, usuMaria);
                ctx.Interessada.AddRange(fulano, maria);
                ctx.Favoritos.AddRange(favoritos);
                ctx.Lance.AddRange(lances);

                //save data
                ctx.Database.OpenConnection();
                try
                {
                    ctx.Database.ExecuteSqlCommand("SET IDENTITY_INSERT dbo.Leiloes ON");
                    ctx.SaveChanges();
                    ctx.Database.ExecuteSqlCommand("SET IDENTITY_INSERT dbo.Leiloes OFF");
                }
                finally
                {
                    ctx.Database.CloseConnection();
                }
            }
        }

        public void Dispose()
        {
            //executar script para limpar o banco de testes
            var dbContextOptions = new DbContextOptionsBuilder<LeiloesContext>()
                .UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=LeiloesDB;Trusted_Connection=true").Options;
            using (var ctx = new LeiloesContext(dbContextOptions))
            {
                //remove data
                ctx.Database.OpenConnection();
                try
                {
                    ctx.Database.ExecuteSqlCommand("TRUNCATE TABLE dbo.Favoritos");
                    ctx.Database.ExecuteSqlCommand("TRUNCATE TABLE dbo.Lances");
                    ctx.Database.ExecuteSqlCommand("TRUNCATE TABLE dbo.Interessadas");
                    ctx.Database.ExecuteSqlCommand("TRUNCATE TABLE dbo.Usuarios");
                    ctx.Database.ExecuteSqlCommand("TRUNCATE TABLE dbo.Leiloes");
                }
                finally
                {
                    ctx.Database.CloseConnection();
                }
            }
            //fechar o navegador
            Driver.Quit();
        }
    }
}
