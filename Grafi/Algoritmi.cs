using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grafi
{
    class Algoritmi
    {
        public static List<Nodo> Bfs(int start, List<Nodo> daEsaminare)
        {
            List<Nodo> visitati = new List<Nodo>();
            Nodo primoNodo = daEsaminare.FirstOrDefault(x => x.Id == start);
            if (primoNodo != null)
            {
                primoNodo.Color = Nodo.Colore.Grey.GetHashCode();
                primoNodo.distanza = 0;
                primoNodo.Predecessore = null;
            }
            List<Nodo> Q = new List<Nodo>
            {
                    primoNodo
            };
            foreach (var nodoCorrente in daEsaminare.Where(x => x.Id != start))
            {
                #region initialize

                nodoCorrente.Color = Nodo.Colore.White.GetHashCode();
                nodoCorrente.distanza = -1;
                nodoCorrente.Predecessore = null;

                #endregion
            }
            while (Q.Count > 0)
            {
                Nodo u = Q.FirstOrDefault();
                foreach (var connessione in u.Connessioni)
                {
                    if (connessione.Color == Nodo.Colore.White.GetHashCode())
                    {
                        connessione.Color = Nodo.Colore.Grey.GetHashCode();
                        connessione.distanza = u.distanza + 1;
                        connessione.Predecessore = u;
                        Q.Add(connessione);
                    }
                }
                u.Color = Nodo.Colore.Black.GetHashCode();
                visitati.Add(u);
                Q.Remove(u);
            }
            return visitati;
        }
    }
}
