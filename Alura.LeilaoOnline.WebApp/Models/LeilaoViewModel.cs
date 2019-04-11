using System;
using Microsoft.AspNetCore.Http;
using Alura.LeilaoOnline.Core;

namespace Alura.LeilaoOnline.WebApp.Models
{
    public class LeilaoViewModel
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public string Categoria { get; set; }
        public string Imagem { get; set; }
        public IFormFile ArquivoImagem { get; set; }
        public double ValorInicial { get; set; }
        public EstadoLeilao Estado { get; set; }
        public DateTime InicioPregao { get; set; }
        public DateTime TerminoPregao { get; set; }
    }
}
