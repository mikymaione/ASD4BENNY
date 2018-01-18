/*
Copyright (C) 2015 [MAIONE MIKY]
This program is free software: you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation, either version 3 of the License, or (at your option) any later version. 
This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU General Public License for more details. 
You should have received a copy of the GNU General Public License along with this program. If not, see http://www.gnu.org/licenses/. 
*/
using System;
using System.Collections.Generic;

namespace Grafi
{
    sealed class Esercizi_20160623 : Grafo
    {

        internal readonly Dictionary<int, string> Etichette;


        public Esercizi_20160623(string nome, Dictionary<int, string> Etichette_) : base(nome)
        {
            Etichette = Etichette_;
        }

        private string getEtichetta(Nodo v)
        {
            if (Etichette.ContainsKey(v.N))
                return Etichette[v.N];

            return "";
        }

        // dato un insieme di etichette P, si scriva un ALG(G, v, p) verifichi se tutti i percorsi infiniti che partono da v passano da almeno un vertice etichettato con p
        public bool Algo_20160623(int v, string p)
        {
            var time = 0;
            var ciclo = false;
            var passato_per_etichetta = false;

            Action<Nodo> Visit = null;
            Visit = (u) =>
            {
                time++;
                u.discovered = time;
                u.color = Nodo.Color.Gray;

                var e = getEtichetta(u);
                if (p.Equals(e))
                    passato_per_etichetta = true;

                foreach (var w in Adj[u])
                    switch (w.color)
                    {
                        case Nodo.Color.White:
                            w.Pred = u;
                            Visit(w);
                            break;
                        case Nodo.Color.Gray:
                            ciclo = true;
                            break;
                    }

                time++;
                u.finished = time;
                u.color = Nodo.Color.Black;
            };

            var n = get_nodo(v);
            Visit(n);

            var r = ciclo && passato_per_etichetta;

            Console.WriteLine("Per il grafo {0} {1}tutti i percorsi infiniti che partono da {2} passano da almeno un vertice etichettato con {3}", Nome, (r ? "" : "non "), v, p);

            return r;
        }


    }
}