using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grafi
{
    class Program
    {
        static void Main(string[] args)
        {
            Random r = new Random();
            int quantiNodi = r.Next(4, 6);
            List<Nodo> daUtilizzare = new List<Nodo>(quantiNodi);
            for (int i = 0; i < quantiNodi; i++)
            {
                daUtilizzare.Add(new Nodo(i));
            }
            List<Nodo> Collegati = new List<Nodo>(quantiNodi);
            foreach (var n in daUtilizzare)
            {
                foreach (var nn in daUtilizzare.Where(x=>x.Id!=n.Id))
                {
                    if (r.Next(0, 3) >= 2)
                    {
                        if (!n.Connessioni.Contains(nn))
                            n.Connessioni.Add(nn);
                        if(!nn.Connessioni.Contains(n))
                            nn.Connessioni.Add(n);
                    }
                }
                Collegati.Add(n);
            }
            var start = r.Next(0, quantiNodi);
            var ritornato = Algoritmi.Bfs(start,Collegati);
            int k = 0;
            k++;
        }
    }
}
