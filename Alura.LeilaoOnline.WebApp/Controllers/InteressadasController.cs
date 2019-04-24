using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Alura.LeilaoOnline.WebApp.Filtros;
using Alura.LeilaoOnline.WebApp.Models;
using Alura.LeilaoOnline.Core;
using Alura.LeilaoOnline.WebApp.Dados;
using Alura.LeilaoOnline.WebApp.Extensions;

namespace Alura.LeilaoOnline.WebApp.Controllers
{
    [AutorizacaoFilter]
    public class InteressadasController : Controller
    {

        private readonly IRepositorio<Leilao> _repoLeilao;
        private readonly IRepositorio<Interessada> _repoInteressada;

        public InteressadasController(
            IRepositorio<Leilao> repoLeilao, 
            IRepositorio<Interessada> repoInteressada)
        {
            _repoLeilao = repoLeilao;
            _repoInteressada = repoInteressada;
        }

        public IActionResult Index()
        {
            var usuarioLogado = this.HttpContext.Session.Get<Usuario>("usuarioLogado");
            var model = new DashboardInteressadaViewModel
            {
                MinhasOfertas = _repoInteressada.BuscarPorId(usuarioLogado.Id).Lances,
                //LeiloesFavoritos = _repoInteressada
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult OfertaLance(LanceViewModel model)
        {
            if (ModelState.IsValid)
            {
                Leilao leilao = _repoLeilao.BuscarPorId(model.LeilaoId);
                Interessada interessada = _repoInteressada.BuscarPorId(model.UsuarioLogadoId);
                leilao.RecebeLance(interessada, model.Valor);
                _repoLeilao.Alterar(leilao); //?
                return Ok();
            }
            return BadRequest();
        }
    }
}