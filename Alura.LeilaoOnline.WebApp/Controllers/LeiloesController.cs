using Microsoft.AspNetCore.Mvc;
using Alura.LeilaoOnline.WebApp.Models;

namespace Alura.LeilaoOnline.WebApp.Controllers
{
    public class LeiloesController : Controller
    {
        public IActionResult Index()
        {
            //var leiloes = _dao.Todos.ToPagina();
            return View();
        }

        public IActionResult Categoria(string id)
        {
            ViewData["categoria"] = id;
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
                //_dao.Incluir(model);
                return RedirectToAction("Index");
            }
            return View("Novo", model);
        }

        [HttpPost]
        public IActionResult Remove(int id)
        {
            //var leilao = _dao.BuscarPorId(id);
            return RedirectToAction("Index");
        }

        //[HttpGet]
        //public IActionResult Visualiza(int id)
        //{
        //    var leilao 
        //    return View(leilao);
        //}
    }
}