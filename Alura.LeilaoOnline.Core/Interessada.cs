using System.Collections.Generic;

namespace Alura.LeilaoOnline.Core
{
    public class Interessada
    {
        public string Nome { get; }
        public IEnumerable<Lance> Lances { get; set; }

        public Interessada(string nome)
        {
            Nome = nome;
        }
    }
}
