using Microsoft.AspNetCore.Http;

namespace Alura.LeilaoOnline.WebApp.Models
{
    public class LeilaoViewModel
    {
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public string Imagem { get; set; }
        public IFormFile ArquivoImagem { get; set; }
        public double ValorInicial { get; set; }
        public string Estado { get; set; }
    }
}
