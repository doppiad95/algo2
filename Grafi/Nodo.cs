using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grafi
{
    class Nodo
    {
        public int Id { get; set; }
        public List<Nodo> Connessioni { get; set; }
        public int distanza { get; set; }

        public enum Colore
        {
            White, Grey, Black
        }
        public int Color { get; set; }
        public Nodo Predecessore { get; set; }
        public Nodo(int i)
        {
            Id = i;
            Connessioni = new List<Nodo>();
        }

        public Nodo(int i, List<Nodo> c)
        {
            Id = i;
            Connessioni = c;
        }
    }
}
