using Microsoft.AspNetCore.Mvc;
using Alura.LeilaoOnline.WebApp.Models;

namespace Alura.LeilaoOnline.WebApp.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Detalhes()
        {
            var leilao = new LeilaoViewModel
            {
                Titulo = "Réplica de Pintura",
                Descricao = "Lorem ipsum dolor sit amet consectetur adipisicing elit. Dignissimos officia repellat sed repudiandae deleniti aperiam et atque. Blanditiis, deserunt natus.",
                Imagem = "/images/painting1.jpg",
                ValorInicial = 1200.00,
                Estado = "Pregão não iniciado"
            };
            return View(leilao);
        }

        public IActionResult DetalhesPregaoAndamento()
        {
            var leilao = new LeilaoViewModel
            {
                Titulo = "Piano clássico",
                Descricao = "Lorem ipsum dolor sit amet consectetur adipisicing elit. Dignissimos officia repellat sed repudiandae deleniti aperiam et atque. Blanditiis, deserunt natus.",
                Imagem = "/images/instrumento2.jpg",
                ValorInicial = 15200.00,
                Estado = "Pregão em andamento"
            };
            return View("Detalhes", leilao);
        }
    }
}