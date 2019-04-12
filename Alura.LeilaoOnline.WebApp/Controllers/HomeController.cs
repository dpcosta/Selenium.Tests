using Microsoft.AspNetCore.Mvc;
using Alura.LeilaoOnline.WebApp.Models;
using Alura.LeilaoOnline.WebApp.Dados;
using Alura.LeilaoOnline.Core;
using System.Linq;
using Alura.LeilaoOnline.WebApp.Extensions;

namespace Alura.LeilaoOnline.WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IRepositorio<Leilao> _repo;

        public HomeController(IRepositorio<Leilao> repositorio)
        {
            _repo = repositorio;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var proximosLeiloes = _repo.Todos
                .Where(l => l.Estado == EstadoLeilao.LeilaoAntesDoPregao)
                .OrderBy(l => l.InicioPregao)
                .Take(6)
                .Select(l => l.ToViewModel());
            return View(proximosLeiloes);
        }

        [HttpGet]
        public IActionResult Detalhes(int id)
        {
            var leilao = _repo.BuscarPorId(id).ToViewModel();
            if (leilao != null)
            {
                return View(leilao);
            }
            return NotFound();
        }

        [HttpGet]
        public IActionResult Categoria(string id)
        {
            ViewData["categoria"] = id;
            var leiloes = _repo.Todos
                .Where(l => l.Categoria == id)
                .Select(l => l.ToViewModel());
            return View("Index", leiloes);
        }

    }
}