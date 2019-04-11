using Microsoft.AspNetCore.Mvc;
using Alura.LeilaoOnline.WebApp.Models;
using System.Collections.Generic;

namespace Alura.LeilaoOnline.WebApp.Controllers
{
    public class LeiloesController : Controller
    {
        public IActionResult Index()
        {
            //var leiloes = _repo.Todos.ToPagina();
            return View();
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