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
    sealed class Esercizi : Grafo
    {

        public Esercizi(string nome) : base(nome) { }


        public void Alg_20171016(dynamic[] B)
        {
            try
            {
                Alg_20171016_(B);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void Alg_20171016_(dynamic[] B_numeri)
        {
            Action<Grafo, Nodo> dfs_visita = null;
            dfs_visita = (TheG, u) =>
            {
                u.color = Nodo.Color.Gray;

                foreach (var v in TheG.Adj[u])
                    if (v.color == Nodo.Color.White)
                    {
                        v.Pred = u;
                        dfs_visita(TheG, v);
                    }

                u.color = Nodo.Color.Black;
            };

            var B_nodi = new Nodo[B_numeri.Length];
            for (var i = 0; i < B_numeri.Length; i++)
                B_nodi[i] = get_nodo(B_numeri[i]);

            //inizio            
            var V1 = new HashSet<Nodo>();
            var V2 = new HashSet<Nodo>();
            var VU = new HashSet<Nodo>();

            foreach (var x in V)
            {
                x.color = Nodo.Color.White;
                VU.Add(x);
            }

            foreach (var x in B_nodi)
                dfs_visita(this, x);

            foreach (var x in B_nodi)
                x.color = Nodo.Color.White;

            foreach (var x in V)
                if (x.color == Nodo.Color.Black)
                {
                    V2.Add(x);
                    if (!VU.Remove(x))
                        throw new Exception("Gli insiemi non esistono!");
                }

            Sbianca();

            // GT ---------------------------------------------------
            var Gt = Trasposto($"Gt_{Nome}", true);

            foreach (var x in B_numeri)
                Gt.get_nodo(x).color = Nodo.Color.Black;

            foreach (var x in B_nodi)
                dfs_visita(Gt, x);

            foreach (var x in B_numeri)
                Gt.get_nodo(x).color = Nodo.Color.White;

            foreach (var x in Gt.V)
                if (x.color == Nodo.Color.Black)
                {
                    V1.Add(x);
                    if (!VU.Remove(x))
                        throw new Exception("Gli insiemi non esistono!");
                }
            // GT ---------------------------------------------------

            Console.WriteLine(Nome);

            Console.WriteLine("V1:");
            foreach (var v in V1)
                Console.Write($"{v.N} ");
            Console.WriteLine("");

            Console.WriteLine("V2:");
            foreach (var v in V2)
                Console.Write($"{v.N} ");

            Console.WriteLine(Environment.NewLine + Environment.NewLine);
        }

        /// <summary>
        /// Sia dato un grafo orientato G, e 3 vertici a,b,c;
        /// Si scriva un algoritmo che verifichi se ogni percorso infinito che parte da a e passa per b passa necessariamente anche dal vertice c prima di raggiungere b.
        /// </summary>
        /// <returns><c>true</c>, se e soltanto se il vertice c compare prima di b lungo ogni percorso infinito che parte da a e passa per b, <c>false</c> altrimenti.</returns>
        /// <param name="a">Nodo a</param>
        /// <param name="b">Nodo b</param>
        /// <param name="c">Nodo c</param>
        public bool Alg_20170718_2(dynamic a, dynamic b, dynamic c)
        {
            KPaths(a, b);

            return Alg_20170718_2_(
                get_nodo(a),
                get_nodo(b),
                get_nodo(c)
            );
        }

        //non funziona
        private bool Alg_20170718_2_(Nodo a, Nodo b, Nodo c)
        {
            var esiste = false;

            Func<Nodo, bool> dfs_visit_2 = null;
            dfs_visit_2 = (u) =>
            {
                u.color = Nodo.Color.Gray;

                foreach (var v in Adj[u])
                    if (v.color == Nodo.Color.Gray)
                        return false;
                    else if (v.color == Nodo.Color.White)
                        if (!dfs_visit_2(v))
                            return false;

                u.color = Nodo.Color.Black;

                return true;
            };

            Action<Nodo> dfs_visit_1 = null;
            dfs_visit_1 = (u) =>
            {
                u.color = Nodo.Color.Gray;

                foreach (var v in Adj[u])
                    if (v.color == Nodo.Color.White)
                        dfs_visit_1(v);

                u.color = Nodo.Color.Black;
            };

            Sbianca();
            c.color = Nodo.Color.Black;
            dfs_visit_1(a);

            if (b.color == Nodo.Color.White)
                esiste = true;
            else
            {
                Sbianca();
                esiste = dfs_visit_2(b);
            }

            if (esiste)
                Console.WriteLine("Nel grafo {0}, tutti i percorsi {1} ~> {2} ~> {3} ~> ∞ sono veri" + Environment.NewLine, Nome, a.N, c.N, b.N);
            else
                Console.WriteLine("Nel grafo {0}, esiste un percorso per cui {1} ~> {2} ~> {3} ~> ∞ non è vera" + Environment.NewLine, Nome, a.N, c.N, b.N);

            return esiste;
        }

        public bool Alg_20170718_1(int x)
        {
            var ciclo_da_x = false;

            var scc = SCC();

            foreach (var c in scc)
                if (c.Count >= x)
                {
                    ciclo_da_x = true;
                    break;
                }

            Console.WriteLine("Nel grafo {0}, {1}esiste un ciclo di {2} nodi", Nome, (ciclo_da_x ? "" : "Non "), x);

            SCC_Print(scc);

            return !ciclo_da_x;
        }

        public bool Alg_20170628_2(int a, int b, int c)
        {
            var Ciclo = false;
            var ElaborazioneTerminataENessunCicloTrovato = false;

            var n_a = get_nodo(a);
            var n_b = get_nodo(b);
            var n_c = get_nodo(c);

            var S = new Stack<Nodo>();
            S.Push(n_c);
            S.Push(n_b);
            S.Push(n_a);

            Action<Nodo> dfs = null;
            dfs = (u) =>
            {
                u.color = Nodo.Color.Gray;

                if (S.Count > 0 && u == S.Peek())
                    S.Pop();

                foreach (var v in Adj[u])
                    if (v.color == Nodo.Color.White)
                        dfs(v);
                    else if (S.Count < 1 && v.color == Nodo.Color.Gray)
                        Ciclo = true;

                if (!Ciclo && S.Count < 1)
                    ElaborazioneTerminataENessunCicloTrovato = true;

                u.color = Nodo.Color.Black;
            };

            Sbianca();
            dfs(n_a);
            var r = (Ciclo && !ElaborazioneTerminataENessunCicloTrovato);

            Console.WriteLine("Nel grafo {0}, {1}esiste un percorso {2} ~> {3} ~> {4} ~> ∞", Nome, (r ? "" : "Non "), a, b, c);

            return r;
        }

        public bool Alg_20170628_1(int a, int b, int c, int d)
        {
            var n_a = get_nodo(a);
            var n_b = get_nodo(b);
            var n_c = get_nodo(c);
            var n_d = get_nodo(d);

            var passati_tutti = false;
            var ciclo = false;

            Func<Nodo, bool> dfs = null;
            dfs = (u) =>
            {
                u.color = Nodo.Color.Gray;

                foreach (var v in Adj[u])
                {
                    if (v == n_d)
                        passati_tutti = (n_a.color != Nodo.Color.White && n_b.color != Nodo.Color.White && n_c.color != Nodo.Color.White);

                    if (v.color == Nodo.Color.White)
                    {
                        if (!dfs(v))
                            return false;
                    }
                    else if (passati_tutti && v.color == Nodo.Color.Gray)
                        ciclo = true;
                }

                u.color = Nodo.Color.Black;

                return (!passati_tutti || ciclo);
            };

            Sbianca();
            var r = dfs(n_a);

            passati_tutti = (n_a.color != Nodo.Color.White && n_b.color != Nodo.Color.White && n_c.color != Nodo.Color.White && n_d.color != Nodo.Color.White);
            r = (r && ciclo && passati_tutti);

            Console.WriteLine("Nel grafo {0}, {1}esiste un percorso {2} ~> {3} ~> {4} ~> {5} ~> ∞", Nome, (r ? "" : "Non "), a, b, c, d);

            return r;
        }

        public void Alg_20160219(dynamic[] A, int u, int v)
        {
            var R = Alg_20160219(A, get_nodo(u), get_nodo(v));

            Console.Write(string.Format("\n{0}: ", Nome));
            foreach (var a in R)
                Console.Write(a.N + " ");
        }

        private HashSet<Nodo> Alg_20160219(dynamic[] A, Nodo u, Nodo v)
        {
            var R = new HashSet<Nodo>();

            Action<Nodo> setPercorso = null;
            setPercorso = (a) =>
            {
                if (a != null)
                {
                    if (a != v & a != u)
                        foreach (var x in A)
                            if (x == a.N)
                            {
                                R.Add(a);
                                break;
                            }

                    setPercorso(a.Pred);
                }
            };

            Action<Nodo> Visita = null;
            Visita = (x) =>
            {
                x.color = Nodo.Color.Gray;

                if (x == v)
                    setPercorso(x);

                foreach (var y in Adj[x])
                    if (y.color == Nodo.Color.White)
                    {
                        y.Pred = x;
                        Visita(y);
                    }

                x.color = Nodo.Color.White;
            };

            Visita(u);

            return R;
        }

        /// <summary>
        /// O(2(V+E))
        /// </summary>
        /// <param name="B"></param>
        public void Algo_20170224(int[] B)
        {
            Console.WriteLine(string.Format("{0} contains [{1}]? {2}\n", Nome, string.Join(" ", B), Algo_20170224_p(B)));
        }

        private bool Algo_20170224_p(int[] B)
        {
            var Ciclico = false;
            var Z0 = new HashSet<int>(B);
            var Z1 = new HashSet<int>(B);
            var Z2 = new HashSet<int>(B);

            Action<Grafo, Nodo> myDFS_Visita = null;
            myDFS_Visita = (G, u) =>
            {
                u.color = Nodo.Color.Gray;

                foreach (var v in G.Adj[u])
                    switch (v.color)
                    {
                        case Nodo.Color.White:
                            v.Pred = u;
                            myDFS_Visita(G, v);
                            break;
                        case Nodo.Color.Gray:
                            foreach (var z in Z0)
                                if (z == v.N)
                                {
                                    Ciclico = true;
                                    break;
                                }
                            break;
                    }

                u.color = Nodo.Color.Black;
            };

            this.Sbianca();
            Ciclico = false;
            myDFS_Visita(this, this.get_nodo(B[0]));

            if (Ciclico)
            {
                var Gt = Trasposto(Nome + "t", false);
                Gt.Sbianca();
                Ciclico = false;
                myDFS_Visita(Gt, Gt.get_nodo(B[0]));

                if (Ciclico)
                {
                    foreach (var v in this.V)
                        if (v.color == Nodo.Color.Black)
                            Z1.Remove(v.N);

                    foreach (var v in Gt.V)
                        if (v.color == Nodo.Color.Black)
                            Z2.Remove(v.N);

                    return (Z1.Count == 0 && Z2.Count == 0);
                }
            }

            return false;
        }

        //ok
        public void Algo_20160128(int[] A)
        {
            var r1 = true;
            var r2 = true;

            var Gt = this.Trasposto("Gt_" + Nome, false);

            this.DFS_Visita(A[0]);
            Gt.DFS_Visita(A[0]);

            foreach (var v in A)
                if (this.get_nodo(v).color != Nodo.Color.Black)
                {
                    r1 = false;
                    break;
                }

            foreach (var v in A)
                if (Gt.get_nodo(v).color != Nodo.Color.Black)
                {
                    r2 = false;
                    break;
                }

            var r = r1 && r2;
            Console.WriteLine("Per il grafo {0}, {1}esiste un percorso che passa per [{2}, {3}]", Nome, (r ? "" : "non "), string.Join(",", A), A[0]);
        }

        // dati 3 vertici u, z, v, si verifichi se tutti i percorsi da u a v, passando per z, hanno lunghezza maggiore di k
        public bool Algo_20160623(int u, int z, int v, int k)
        {
            var n_u = get_nodo(u);
            var n_z = get_nodo(z);
            var n_v = get_nodo(v);

            BFS(u, int.MaxValue);

            var qualcuno = (n_u.distance < int.MaxValue && n_z.distance < int.MaxValue && n_v.distance < int.MaxValue);
            var qualcuno_minore = (Math.Max(n_z.distance, n_v.distance) <= k);

            Console.WriteLine("Per il grafo {0} tutti i percorsi che passano per {1}, {2}, {3} {4}hanno lunghezza maggiore di {5}", Nome, u, z, v, (qualcuno && !qualcuno_minore ? "" : "NON "), k);

            return qualcuno_minore;
        }

        /// <summary>
        /// result = ∃ u,v,z | {[∃1 π | (u⇝v⇝z)] ∧ [∃ π | (x⇝u⇝z⇝v)]}
        /// </summary>
        public void Algo_20170126_1()
        {
            Console.WriteLine($"Algo_20170126_1({Nome})");

            Action<Dictionary<Nodo, HashSet<Nodo>>, Nodo, Nodo> simple_paths = null;
            simple_paths = (Paths, s, n) =>
            {
                var L = Paths.Peek();
                L.Add(n);

                n.color = Nodo.Color.Gray;

                foreach (var v in Adj[n])
                    if (v.color == Nodo.Color.White)
                    {
                        simple_paths(Paths, s, v);
                        Paths.Push(new List<Nodo>(L));
                    }

                n.color = Nodo.Color.White; //simple paths
            };

            foreach (var s in V)
            {
                var Paths = new Dictionary<Nodo, HashSet<Nodo>>();
                simple_paths(Paths, s, s);

                Console.WriteLine($"P da {s.N}: ");
                foreach (var L in Paths)
                    if (L.Count > 1)
                    {
                        foreach (var l in L)
                            Console.Write($"{l.N}→");
                        Console.WriteLine();
                    }
            }
        }

        /// <summary>
        /// O(V(V+E))
        /// </summary>
        public void Algo_20170126_2()
        {
            Action<Nodo> myBFS = (s) =>
            {
                Sbianca();

                var Z = new HashSet<Nodo>(V);
                var Q = new Queue<Nodo>();
                Q.Enqueue(s);

                s.color = Nodo.Color.Gray;
                s.distance = 0;
                Z.Remove(s);

                while (Q.Count > 0)
                {
                    var v = Q.Dequeue();

                    foreach (var w in Adj[v])
                        if (w.color == Nodo.Color.White)
                        {
                            w.color = Nodo.Color.Gray;
                            w.distance = v.distance + 1;
                            w.Pred = v;
                            Q.Enqueue(w);
                            Z.Remove(w);
                        }

                    v.color = Nodo.Color.Black;
                }

                if (Z.Count > 0)
                {
                    Console.Write(string.Format("{0} non raggiunge: ", s.N));
                    foreach (var z in Z)
                        Console.Write(z.N + " ");
                }
                else
                    Console.Write(string.Format("{0} raggiunge tutti i nodi", s.N));

                Console.WriteLine();
            };

            Console.WriteLine(string.Format("\n{0}", Nome));

            foreach (var v in V)
                myBFS(v);
        }

        /// <summary>
        /// O(3(V+E))
        /// </summary>
        public void Algo_20160909(int vv, int uu, int kk, int zz)
        {
            var ok = Algo_20160909(
                         get_nodo(vv),
                         get_nodo(uu),
                         get_nodo(kk),
                         get_nodo(zz)
                     );

            var non = (ok ? "" : "non ");
            Console.WriteLine(string.Format("Per il grafo {0} {1}esiste un percorso che parte da {2} passa per {3} passa poi per {4} e arriva a {5}", Nome, non, vv, kk, zz, uu));
        }

        private bool Algo_20160909(Nodo vv, Nodo uu, Nodo kk, Nodo zz)
        {
            Action<Nodo> myBFS = (s) =>
            {
                Sbianca();

                var Q = new Queue<Nodo>();
                Q.Enqueue(s);

                s.color = Nodo.Color.Gray;
                s.distance = 0;

                while (Q.Count > 0)
                {
                    var v = Q.Dequeue();

                    foreach (var w in Adj[v])
                        if (w.color == Nodo.Color.White)
                        {
                            w.color = Nodo.Color.Gray;
                            w.distance = v.distance + 1;
                            w.Pred = v;
                            Q.Enqueue(w);
                        }

                    v.color = Nodo.Color.Black;
                }
            };

            Func<Nodo, Nodo, bool> VerificaPercorso = null;
            VerificaPercorso = (da, a) =>
            {
                if (da.color != Nodo.Color.Black || a.color != Nodo.Color.Black)
                    return false;

                if (da == a) //arrivato
                    return true;
                else if (a.Pred == null)
                    return false;
                else
                    return VerificaPercorso(da, a.Pred);
            };

            myBFS(vv);
            if (!VerificaPercorso(vv, kk))
                return false;

            myBFS(kk);
            if (!VerificaPercorso(kk, zz))
                return false;

            myBFS(zz);
            if (!VerificaPercorso(zz, uu))
                return false;

            return true;
        }


    }
}