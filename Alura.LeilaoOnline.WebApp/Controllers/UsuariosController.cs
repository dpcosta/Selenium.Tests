using Microsoft.AspNetCore.Mvc;
using Alura.LeilaoOnline.WebApp.Models;

namespace Alura.LeilaoOnline.WebApp.Controllers
{
    public class UsuariosController : Controller
    {
        [HttpPost]
        public IActionResult Registro(RegistroViewModel model)
        {
            if (ModelState.IsValid)
            {
                //registrar usuário
                return RedirectToAction("Agradecimento");
            }
            return View("~/Views/Home/Index.cshtml", model);
        }

        [HttpGet]
        public IActionResult Agradecimento()
        {
            return View();
        }
    }
}