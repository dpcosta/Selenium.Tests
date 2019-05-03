using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Diagnostics;
using System.Collections.Generic;
using Alura.LeilaoOnline.Core;
using Alura.LeilaoOnline.Selenium.Helpers;
using Alura.LeilaoOnline.WebApp.Dados;
using Microsoft.EntityFrameworkCore;

namespace Alura.LeilaoOnline.Selenium.Fixtures
{
    public sealed class WebDriverFixture : IDisposable
    {
        public IWebDriver Driver { get; private set; }

        private void InicializarDatabaseDeTestes()
        {
            //executar script para criar o banco de testes
            var dbContextOptions = new DbContextOptionsBuilder<LeiloesContext>()
                .UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=LeiloesDB_Tests;Trusted_Connection=true").Options;

            using (var ctx = new LeiloesContext(dbContextOptions))
            {
                ctx.Database.OpenConnection();
                try
                {
                    //0 - Zerar banco de dados
                    ctx.Database.ExecuteSqlCommand("TRUNCATE TABLE dbo.Favoritos");
                    ctx.Database.ExecuteSqlCommand("TRUNCATE TABLE dbo.Lance");
                    ctx.Database.ExecuteSqlCommand("TRUNCATE TABLE dbo.Interessada");
                    ctx.Database.ExecuteSqlCommand("TRUNCATE TABLE dbo.Usuarios");
                    ctx.Database.ExecuteSqlCommand("TRUNCATE TABLE dbo.Leiloes");

                    //I - Dados

                    //I.1 - Interessadas
                    var fulano = new Interessada("Fulano de Tal") { Id = 1 };
                    var maria
                        = new Interessada("Maria da Silva") { Id = 2 };

                    //I.2 - Usuários
                    var admin = new Usuario { Id = 1, Email = "admin@example.org", Senha = "123" };
                    var usuFulano = new Usuario { Id = 2, Email = "fulano@example.org", Senha = "123", Interessada = fulano };
                    var usuMaria = new Usuario { Id = 3, Email = "maria@example.org", Senha = "123", Interessada = maria };

                    //I.3 - Leilões
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

                    var leilaoInstrumento1 = new Leilao("Leilão de Instrumento 1", null)
                    {
                        Id = 11,
                        Descricao = "Lorem ipsum dolor sit amet consectetur adipisicing elit. Nisi quibusdam esse saepe doloribus culpa ratione enim? Praesentium quaerat libero iure animi distinctio temporibus necessitatibus error. Soluta ab natus quia iusto!",
                        Categoria = "Item de Colecionador",
                        Imagem = "/images/instrumento1.jpg",
                        ValorInicial = 8259.99,
                        InicioPregao = DateTime.Now.AddDays(-2),
                        TerminoPregao = DateTime.Now.AddDays(2),
                    };
                    var leilaoInstrumento2 = new Leilao("Leilão de Instrumento 2", null)
                    {
                        Id = 12,
                        Descricao = "Lorem ipsum dolor sit amet consectetur adipisicing elit. Nisi quibusdam esse saepe doloribus culpa ratione enim? Praesentium quaerat libero iure animi distinctio temporibus necessitatibus error. Soluta ab natus quia iusto!",
                        Categoria = "Item de Colecionador",
                        Imagem = "/images/instrumento2.jpg",
                        ValorInicial = 6400.37,
                        InicioPregao = DateTime.Now.AddDays(-1),
                        TerminoPregao = DateTime.Now.AddDays(3),
                    };
                    var leilaoInstrumento3 = new Leilao("Leilão de Instrumento 3", null)
                    {
                        Id = 13,
                        Descricao = "Lorem ipsum dolor sit amet consectetur adipisicing elit. Nisi quibusdam esse saepe doloribus culpa ratione enim? Praesentium quaerat libero iure animi distinctio temporibus necessitatibus error. Soluta ab natus quia iusto!",
                        Categoria = "Item de Colecionador",
                        Imagem = "/images/instrumento3.jpg",
                        ValorInicial = 3857.90,
                        InicioPregao = DateTime.Now.AddDays(3),
                        TerminoPregao = DateTime.Now.AddDays(7),
                    };
                    var leilaoInstrumento4 = new Leilao("Leilão de Instrumento 4", null)
                    {
                        Id = 14,
                        Descricao = "Lorem ipsum dolor sit amet consectetur adipisicing elit. Nisi quibusdam esse saepe doloribus culpa ratione enim? Praesentium quaerat libero iure animi distinctio temporibus necessitatibus error. Soluta ab natus quia iusto!",
                        Categoria = "Item de Colecionador",
                        Imagem = "/images/instrumento4.jpg",
                        ValorInicial = 17280.0,
                        InicioPregao = DateTime.Now.AddDays(5),
                        TerminoPregao = DateTime.Now.AddDays(15),
                    };
                    var leilaoInstrumento5 = new Leilao("Leilão de Instrumento 5", null)
                    {
                        Id = 15,
                        Descricao = "Lorem ipsum dolor sit amet consectetur adipisicing elit. Nisi quibusdam esse saepe doloribus culpa ratione enim? Praesentium quaerat libero iure animi distinctio temporibus necessitatibus error. Soluta ab natus quia iusto!",
                        Categoria = "Item de Colecionador",
                        Imagem = "/images/instrumento5.jpg",
                        ValorInicial = 5420.0,
                        InicioPregao = DateTime.Now.AddDays(-5),
                        TerminoPregao = DateTime.Now.AddDays(-1),
                    };

                    //II - Cenários...

                    leilaoArte1.IniciaPregao();
                    leilaoArte2.IniciaPregao();
                    leilaoArte5.IniciaPregao();
                    //adicionar lances
                    leilaoArte5.RecebeLance(fulano, 1560);
                    leilaoArte5.RecebeLance(maria, 1670);
                    leilaoArte5.RecebeLance(fulano, 1800);
                    leilaoArte5.TerminaPregao();

                    leilaoAuto1.IniciaPregao();
                    leilaoAuto2.IniciaPregao();
                    leilaoAuto5.IniciaPregao();
                    //adicionar lances
                    leilaoAuto5.RecebeLance(fulano, 16000.0);
                    leilaoAuto5.RecebeLance(maria, 20000.0);
                    leilaoAuto5.TerminaPregao();

                    leilaoInstrumento1.IniciaPregao();
                    leilaoInstrumento2.IniciaPregao();
                    leilaoInstrumento5.IniciaPregao();
                    //adicionar lances
                    leilaoInstrumento5.RecebeLance(fulano, 6200);
                    leilaoInstrumento5.RecebeLance(maria, 6300);
                    leilaoInstrumento5.RecebeLance(fulano, 6400);
                    leilaoInstrumento5.RecebeLance(maria, 6500);
                    leilaoInstrumento5.RecebeLance(fulano, 6800);
                    leilaoInstrumento5.TerminaPregao();

                    //favoritos
                    var favoritos = new List<Favorito>
                    {
                        new Favorito { IdInteressada = 1, IdLeilao = 1 },
                        new Favorito { IdInteressada = 1, IdLeilao = 6 },
                        new Favorito { IdInteressada = 1, IdLeilao = 8 },
                        new Favorito { IdInteressada = 1, IdLeilao = 10 },
                        new Favorito { IdInteressada = 1, IdLeilao = 15 },
                        new Favorito { IdInteressada = 2, IdLeilao = 3 },
                        new Favorito { IdInteressada = 2, IdLeilao = 5 },
                        new Favorito { IdInteressada = 2, IdLeilao = 8 },
                        new Favorito { IdInteressada = 2, IdLeilao = 9 },
                    };

                    ctx.Leiloes.AddRange(
                        leilaoArte1,
                        leilaoArte2,
                        leilaoArte3,
                        leilaoArte4,
                        leilaoArte5,
                        leilaoAuto1,
                        leilaoAuto2,
                        leilaoAuto3,
                        leilaoAuto4,
                        leilaoAuto5,
                        leilaoInstrumento1,
                        leilaoInstrumento2,
                        leilaoInstrumento3,
                        leilaoInstrumento4,
                        leilaoInstrumento5
                    );

                    ctx.Usuarios.AddRange(admin, usuFulano, usuMaria);
                    ctx.Interessada.AddRange(fulano, maria);
                    ctx.Favoritos.AddRange(favoritos);

                    //III. Save data
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

        private void ExecutaComandoNoTerminal(string filename, string args, string workDir)
        {
            var process = new Process
            {
                StartInfo =
                    {
                        FileName = filename,
                        Arguments = args,
                        //está apontando para o diretório da assembly de testes?
                        WorkingDirectory = workDir
                    }
            };
            process.Start();

        }

        private void InicializarWebApp()
        {
            var process = new Process
            {
                StartInfo =
                    {
                        FileName = "dotnet",
                        Arguments = "run",
                        //está apontando para o diretório da assembly de testes?
                        WorkingDirectory = TestHelper.PastaWebApp
                    }
            };
            process.Start();
        }

        public WebDriverFixture()
        {
            Driver = new ChromeDriver(TestHelper.PastaDoExecutavel);

            InicializarDatabaseDeTestes();

            //startar web app apontando para o banco de testes
            InicializarWebApp();
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
                    ctx.Database.ExecuteSqlCommand("TRUNCATE TABLE dbo.Lance");
                    ctx.Database.ExecuteSqlCommand("TRUNCATE TABLE dbo.Interessada");
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
