﻿using System;
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
        public static List<Nodo> BfsUntilDistance(int start, List<Nodo> daEsaminare,int distanzaDiFine)
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

                        connessione.distanza = u.distanza + 1;
                        connessione.Predecessore = u;
                        if (connessione.distanza < distanzaDiFine)
                        {
                            connessione.Color = Nodo.Colore.Grey.GetHashCode();
                            Q.Add(connessione);
                        }
                        else
                            connessione.Color = Nodo.Colore.Black.GetHashCode();
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

        public static void PrintEdgeType(List<Nodo> grafoDaControllare)
        {
            grafoDaControllare = ResettaNodi(grafoDaControllare);
            foreach (var nodo in grafoDaControllare)
            {
                if(nodo.Color == Nodo.Colore.White.GetHashCode())
                    PrintEdgeTypeVisit(nodo);
            }
        }

        private static void PrintEdgeTypeVisit(Nodo nodo)
        {
            nodo.Color = Nodo.Colore.Grey.GetHashCode();
            Time += 1;
            nodo.distanza = Time;
            nodo.inizioVisita = Time;
            foreach (var nodo1 in nodo.Connessioni)
            {
                if (nodo1.Color == Nodo.Colore.White.GetHashCode())
                {
                    Console.WriteLine("("+nodo.Id+","+nodo1.Id+") Arco dell'albero");
                    nodo1.Predecessore = nodo;
                    PrintEdgeTypeVisit(nodo1);
                }
                else if (nodo1.Color == Nodo.Colore.Grey.GetHashCode())
                {
                    Console.WriteLine("(" + nodo.Id + "," + nodo1.Id + ") Arco all'indietro");
                }
                else
                {
                    if(nodo.distanza<nodo1.distanza)
                        Console.WriteLine("(" + nodo.Id + "," + nodo1.Id + ") Arco in avanti");
                    else
                        Console.WriteLine("(" + nodo.Id + "," + nodo1.Id + ") Arco di attraversamento");
                }
            }
            nodo.Color = Nodo.Colore.Black.GetHashCode();
            Time += 1;
            nodo.fineVisita = Time;
        }

        public static void PrintEdgeTypeNo(List<Nodo> grafoDaControllare)
        {
            grafoDaControllare = ResettaNodi(grafoDaControllare);
            foreach (var nodo in grafoDaControllare)
            {
                if (nodo.Color == Nodo.Colore.White.GetHashCode())
                    PrintEdgeTypeVisitNo(nodo);
            }
        }

        private static void PrintEdgeTypeVisitNo(Nodo nodo)
        {
            nodo.Color = Nodo.Colore.Grey.GetHashCode();
            Time += 1;
            nodo.distanza = Time;
            nodo.inizioVisita = Time;
            foreach (var nodo1 in nodo.Connessioni.Where(x => x.Predecessore != null && nodo.Predecessore != null && x.Predecessore != nodo.Predecessore))
            {
                if (nodo1.Color == Nodo.Colore.White.GetHashCode())
                {
                    Console.WriteLine("(" + nodo.Id + "," + nodo1.Id + ") Arco dell'albero");
                    nodo1.Predecessore = nodo;
                    PrintEdgeTypeVisit(nodo1);
                }
                else
                {
                    Console.WriteLine("(" + nodo.Id + "," + nodo1.Id + ") Arco all'indietro");
                }
                
            }
            nodo.Color = Nodo.Colore.Black.GetHashCode();
            Time += 1;
            nodo.fineVisita = Time;
        }


        public static bool IsTree(List<Nodo> grafoDaControllare)
        {
            if (grafoDaControllare != null && grafoDaControllare.FirstOrDefault().IsConntected(grafoDaControllare))
            {
                int e=0, v=grafoDaControllare.Count;
                foreach (var nodo in grafoDaControllare)
                {
                    e += nodo.Connessioni.Count;
                }
                e /= 2;
                if (e == (v - 1))
                    return true;
            }
            return false;
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
            Time = 0;
            return daResettare;
        }
    }
}
