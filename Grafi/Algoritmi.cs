using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Grafi
{
    class Algoritmi
    {
        public static int Time = 0;
        private static List<Nodo> esaminatiDfs = new List<Nodo>();
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

        public static List<Nodo> Dfs(List<Nodo> daEsaminare)
        {

            foreach (var nodo in daEsaminare)
            {
                nodo.Color = Nodo.Colore.White.GetHashCode();
                nodo.Predecessore = null;
            }
            Time = 0;
            foreach (var nodoCorrente in daEsaminare)
            {
                if (nodoCorrente.Color == Nodo.Colore.White.GetHashCode())
                    DfsVisit(nodoCorrente);
            }
            return esaminatiDfs;
        }

        private static void DfsVisit(Nodo nodoCorrente)
        {
            nodoCorrente.Color = Nodo.Colore.Grey.GetHashCode();
            Time += 1;
            nodoCorrente.inizioVisita = Time;
            foreach (var c in nodoCorrente.Connessioni)
            {
                if (c.Color == Nodo.Colore.White.GetHashCode())
                {
                    c.Predecessore = nodoCorrente;
                    DfsVisit(c);
                }
            }
            nodoCorrente.Color = Nodo.Colore.Black.GetHashCode();
            Time += 1;
            nodoCorrente.fineVisita = Time;
            esaminatiDfs.Add(nodoCorrente);
        }

        public static List<Nodo> ResettaNodi(List<Nodo> daResettare)
        {
            esaminatiDfs.Clear();
            foreach (var r in daResettare)
            {
                r.Color = Nodo.Colore.White.GetHashCode();
                r.distanza = 0;
                r.Predecessore = null;
            }
            return daResettare;
        }
    }
}
