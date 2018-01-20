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
            #region  GenerazioneCasualeNodi

            Random r = new Random();
            //int quantiNodi = r.Next(4, 6);
            //List<Nodo> daUtilizzare = new List<Nodo>(quantiNodi);
            //for (int i = 0; i < quantiNodi; i++)
            //{
            //    daUtilizzare.Add(new Nodo(i));
            //}
            //List<Nodo> Collegati = new List<Nodo>(quantiNodi);
            //foreach (var n in daUtilizzare)
            //{
            //    foreach (var nn in daUtilizzare.Where(x => x.Id != n.Id))
            //    {
            //        if (r.Next(0, 3) >= 2)
            //        {
            //            if (!n.Connessioni.Contains(nn))
            //                n.Connessioni.Add(nn);
            //            if (!nn.Connessioni.Contains(n))
            //                nn.Connessioni.Add(n);
            //        }
            //    }
            //    Collegati.Add(n);
            //}


            #endregion

            #region GenerazioneNonCasuale
            //Grafo pagina 460
            int quantiNodi = 6;
            List<Nodo> daUtilizzare = new List<Nodo>(quantiNodi);
            for (int i = 0; i < quantiNodi; i++)
            {
                daUtilizzare.Add(new Nodo(i));
            }
            List<Nodo> Collegati = new List<Nodo>(quantiNodi);

            //NODO u
            daUtilizzare[0].Connessioni.Add(daUtilizzare[1]);
            daUtilizzare[0].Connessioni.Add(daUtilizzare[2]);
            daUtilizzare[0].lettera = 'u';
            //NODO v
            daUtilizzare[1].Connessioni.Add(daUtilizzare[3]);
            daUtilizzare[1].lettera = 'v';
            //NODO x
            daUtilizzare[2].Connessioni.Add(daUtilizzare[1]);
            daUtilizzare[2].lettera = 'x';
            //NODO y
            daUtilizzare[3].Connessioni.Add(daUtilizzare[2]);
            daUtilizzare[3].lettera = 'y';
            //NODO w
            daUtilizzare[4].Connessioni.Add(daUtilizzare[3]);
            daUtilizzare[4].Connessioni.Add(daUtilizzare[5]);
            daUtilizzare[4].lettera = 'w';
            //NODO z
            daUtilizzare[5].Connessioni.Add(daUtilizzare[5]);
            daUtilizzare[5].lettera = 'z';
            #endregion

            Collegati = daUtilizzare;
            #region ChiamaBFS

            var start = r.Next(0, quantiNodi);
            var ritornato = Algoritmi.Bfs(start, Collegati);

            #endregion

            #region ChiamaDFS

            var ritornatoDFS = Algoritmi.Dfs(daUtilizzare);

            #endregion

            #region CountReachable

            Console.WriteLine("#############CONTA RAGGIUNGIBILI##########");
            foreach (var nodo in daUtilizzare)
            {
                Console.WriteLine("Nodo #"+nodo.Id+" - Nodi raggiungibili:\t"+nodo.CountReachable(daUtilizzare));
            }
            Console.WriteLine("#############FINE CONTA RAGGIUNGIBILI##########\n\n");
            #endregion

            #region CountEvenDistance
            Console.WriteLine("#############CONTA RAGGIUNGIBILI PARI##########");

            foreach (var nodo in daUtilizzare)
            {
                Console.WriteLine("Nodo #" + nodo.Id + " - Nodi pari raggiungibili:\t" + nodo.PrintEvenDistance(daUtilizzare));
            }
            Console.WriteLine("#############FINE CONTA RAGGIUNGIBILI PARI##########\n\n");
            #endregion

            #region BloccaDEBUG

            int k = 0;
            k++;

            #endregion

        }
    }
}
