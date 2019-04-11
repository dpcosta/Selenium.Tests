using Microsoft.AspNetCore.Mvc;
using Alura.LeilaoOnline.Core;
using Alura.LeilaoOnline.WebApp.Models;
using Alura.LeilaoOnline.WebApp.Dados;
using System.Collections.Generic;
using System.Linq;
using Alura.LeilaoOnline.WebApp.Extensions;

namespace Alura.LeilaoOnline.WebApp.Controllers
{
    public class LeiloesController : Controller
    {
        private readonly IRepositorio<Leilao> _repo;

        public LeiloesController(IRepositorio<Leilao> repositorio)
        {
            _repo = repositorio;
        }

        public IActionResult Index()
        {
            var leiloes = _repo.Todos.Select(l => l.ToViewModel());
            return View(leiloes);
        }

        public IActionResult Categoria(string id)
        {
            ViewData["categoria"] = id;
            //var leiloes = _repo.Todos.Where(l => l.Categoria.Contains(id));
            return View();
        }

        [HttpGet]
        public IActionResult Novo()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Novo(LeilaoViewModel model)
        {
            if (ModelState.IsValid)
            {
                //arquivo com a imagem
                //_repo.Incluir(model);
                return RedirectToAction("Index");
            }
            return View("Novo", model);
        }

        [HttpPost]
        public IActionResult Remove(int id)
        {
            //var leilao = _repo.BuscarPorId(id);
            var leilao = new LeilaoViewModel();
            if(leilao != null)
            {
                //_repo.Excluir(leilao);
                return RedirectToAction("Index");
            }
            return NotFound();
        }

        //[HttpGet]
        //public IActionResult Visualiza(int id)
        //{
        //    var leilao = _repo.BuscarPorId(id);
        //    if(leilao != null) {
        //      return View(leilao);
        //    }
        //    return NotFound();
        //}
    }
}