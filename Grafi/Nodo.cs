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
        public int? inizioVisita { get; set; }
        public int? fineVisita { get; set; }
        public char? lettera { get; set; }

        public enum Colore
        {
            White,
            Grey,
            Black
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

        public int CountReachable(List<Nodo> grafoDaControllare)
        {
            var ritornato = Algoritmi.Bfs(this.Id, grafoDaControllare);
            ritornato = ritornato.Where(x => x.Id != this.Id).ToList();
            int i = 0;
            foreach (var r in ritornato)
            {
                if (r.distanza != -1)
                    i++;
            }
            return i;
        }

        public int PrintEvenDistance(List<Nodo> grafoDaControllare)
        {
            var ritornato = Algoritmi.Bfs(this.Id, grafoDaControllare);
            ritornato = ritornato.Where(x => x.Id != this.Id).ToList();
            int i = 0;
            foreach (var r in ritornato)
            {
                if (r.distanza != -1 && r.distanza % 2 == 0)
                    i++;
            }
            return i;
        }
    }
}
