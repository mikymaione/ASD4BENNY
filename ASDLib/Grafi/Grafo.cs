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
    public class Grafo
    {

        public HashSet<Nodo> V = new HashSet<Nodo>();
        public Dictionary<Nodo, HashSet<Nodo>> Adj = new Dictionary<Nodo, HashSet<Nodo>>();
        protected string Nome;

        public enum eIntervallo
        {
            Contiene,
            Contenuto,
            Disgiunto
        }

        public Grafo(string nome)
        {
            Nome = nome;
        }

        public Nodo get_nodo(dynamic i)
        {            
            foreach (var n in V)
                if (n.N.Equals(i))
                    return n;

            return null;
        }

        protected Nodo get_node_or_create(dynamic i)
        {
            var n = get_nodo(i);

            if (n == null)
            {
                n = new Nodo(i);
                V.Add(n);
            }

            return n;
        }

        public void add_edges(dynamic[,] E)
        {
            var max = E.GetLength(0);

            for (var i = 0; i < max; i++)
                add_edge(E[i, 0], E[i, 1]);
        }

        public void add_edge(dynamic da, dynamic a)
        {
            var DA = get_node_or_create(da);
            var A = get_node_or_create(a);

            if (Adj.ContainsKey(DA))
            {
                var l = Adj[DA];
                l.Add(A);
            }
            else
            {
                var l = new HashSet<Nodo>();
                l.Add(A);

                Adj.Add(DA, l);
            }

            if (!Adj.ContainsKey(A))
                Adj.Add(A, new HashSet<Nodo>());
        }

        public void StampaNodi()
        {
            foreach (var n in V)
                Console.WriteLine("{0} | d: {1} | f: {2}", n.N, n.discovered, n.finished);            
        }

        public void Stampa()
        {
            Console.WriteLine("Grafo {0}:", Nome);

            foreach (var a in Adj)
            {
                var s = a.Key.N + " -> ";

                foreach (var n in a.Value)
                    s += n.N + " -> ";

                Console.WriteLine(s);
            }
        }

        public Grafo Trasposto(string nome_, bool UseOriginalNodes)
        {
            var GT = new Grafo(nome_);

            if (UseOriginalNodes)
                foreach (var u in V)
                    GT.V.Add(u);

            foreach (var u in V)
                foreach (var v in Adj[u])
                    GT.add_edge(v.N, u.N);

            return GT;
        }

        public void StampaPercorsoMinimo_BFS(dynamic da, dynamic a)
        {
            Nodo dan = null;
            Nodo an = null;

            foreach (var x in V)
            {
                if (dan == null && x.N == da)
                    dan = x;
                else if (an == null && x.N == a)
                    an = x;

                if (dan != null && an != null)
                    break;
            }

            BFS(dan);
            StampaPercorsoMinimo_BFS(dan, an);
            Console.WriteLine();
        }

        private void StampaPercorsoMinimo_BFS(Nodo da, Nodo a)
        {
            if (da == a) //arrivato
                Console.Write(da.N + " ");
            else if (a.Pred == null)
                Console.WriteLine("Non esiste nessun cammino tra {0} e {1}", da.N, a.N);
            else
            {
                StampaPercorsoMinimo_BFS(da, a.Pred);
                Console.Write(a.N + " ");
            }
        }

        public void BFS(dynamic k, int distanzaPredefinita = 0)
        {
            Sbianca(distanzaPredefinita);

            BFS(get_nodo(k));
        }

        private void BFS(Nodo s)
        {
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
        }

        /// <summary>
        /// Topological sorting, Time: O(|V|+|E|), Nuber of possibile solutions: n!
        /// </summary>        
        public void Topological_Sorting()
        {
            var L = new Stack<Nodo>();

            Action<Nodo> Visit = null;
            Visit = (n) =>
            {
                if (n.color == Nodo.Color.Gray)
                    throw new Exception("not a DAG!");

                if (n.color == Nodo.Color.White)
                {
                    n.color = Nodo.Color.Gray;

                    foreach (var m in Adj[n])
                        Visit(m);

                    n.color = Nodo.Color.Black;
                    L.Push(n);
                }
            };

            Sbianca();
            foreach (var v in V)
                if (v.color == Nodo.Color.White)
                    Visit(v);

            Console.Write("Topological sort: ");
            foreach (var x in L)
                Console.Write(x.N + " ");
            Console.WriteLine();
        }

        public void DFS() //Θ(|V| + |E|)
        {
            var time = 0;

            Sbianca(); //Θ(|V|)
            foreach (var v in V)
                if (v.color == Nodo.Color.White)
                    DFS_Visita(v, ref time);
        }

        public void DFS_Visita(dynamic u, int start_time = 0) //Θ(|E|)
        {
            DFS_Visita(get_nodo(u), ref start_time);
        }

        private void DFS_Visita(Nodo u, ref int time) //Θ(|E|)
        {
            time++;
            u.discovered = time;
            u.color = Nodo.Color.Gray;

            foreach (var v in Adj[u])
                if (v.color == Nodo.Color.White)
                {
                    v.Pred = u;
                    DFS_Visita(v, ref time);
                }

            time++;
            u.finished = time;
            u.color = Nodo.Color.Black;
        }

        public void KPaths(dynamic s, dynamic e)
        {
            Sbianca();

            Nodo ns = get_nodo(s);
            Nodo ne = get_nodo(e);

            Console.WriteLine("{0} KPaths {1} > {2}:", Nome, ns.N, ne.N);

            KPaths(ns, ne, new Stack<Nodo>());
        }

        private void KPaths(Nodo s, Nodo e, Stack<Nodo> paths)
        {
            s.color = Nodo.Color.Gray;
            paths.Push(s);

            if (s == e)
            {       
                var z = "";
                foreach (var x in paths)
                    z = x.N + " > " + z;
                Console.WriteLine(z);
            }
            else
            {
                foreach (var i in Adj[s])
                    if (i.color == Nodo.Color.White)
                        KPaths(i, e, paths);                    
            }

            paths.Pop();
            s.color = Nodo.Color.White;
        }

        public void Sbianca(int distanzaPredefinita = 0)
        {
            foreach (var v in V)
                v.Sbianca(distanzaPredefinita);
        }

        /// <summary>
        /// Print Strongly connected components algorithm
        /// </summary>
        public void SCC_Print(List<List<Nodo>> sccs)
        {
            Console.WriteLine("Strongly connected components su {0}", Nome);

            foreach (var scc in sccs)
            {
                Console.Write("SCC: ");
                foreach (var n in scc)
                    Console.Write(n.N + " ");

                Console.WriteLine();
            }

            Console.WriteLine();
        }

        /// <summary>
        /// Strongly connected components algorithm
        /// </summary>
        public List<List<Nodo>> SCC()
        {
            var L = new Stack<Nodo>();
            var SCC = new List<List<Nodo>>();

            Action<Nodo> Visit = null;
            Visit = (u) =>
            {
                if (u.color == Nodo.Color.White)
                {
                    u.color = Nodo.Color.Gray;

                    foreach (var v in Adj[u])
                        Visit(v);

                    L.Push(u);
                }
            };
                    
            Action<Grafo, Nodo, Nodo, List<Nodo>> Assign = null;
            Assign = (GT, u, root, lista) =>
            {
                if (u.color != Nodo.Color.Black)
                {                        
                    if (u == root)
                    {
                        lista = new List<Nodo>();
                        SCC.Add(lista);
                    }

                    u.color = Nodo.Color.Black;
                    lista.Add(u);

                    foreach (var v in GT.Adj[u])
                        Assign(GT, v, root, lista);
                }
            };

            Sbianca();
            foreach (var u in V)
                Visit(u);

            var Gt = Trasposto(Nome + "_T", true);

            foreach (var u in L)
                Assign(Gt, u, u, null);

            return SCC;
        }

        /// <summary>
        /// Tarjan's strongly connected components algorithm, Time: O(|V|+|E|)
        /// </summary>
        public List<List<Nodo>> Tarjan()
        {
            var indice = 0; // number of nodes
            var S = new Stack<Nodo>();
            var SCC = new List<List<Nodo>>();

            Action<Nodo> StrongConnect = null;
            StrongConnect = (v) =>
            {
                // Set the depth index for v to the smallest unused index
                v.indice = indice;
                v.minima_distanza = indice;

                indice++;
                S.Push(v);
                v.discovered = 1;

                // Consider successors of v
                foreach (var w in Adj[v])
                    if (w.indice < 0)
                    {
                        // Successor w has not yet been visited; recurse on it
                        StrongConnect(w);
                        v.minima_distanza = Math.Min(v.minima_distanza, w.minima_distanza);
                    }
                    else if (w.discovered > 0)
                        // Successor w is in stack S and hence in the current SCC
                        v.minima_distanza = Math.Min(v.minima_distanza, w.indice);

                // If v is a root node, pop the stack and generate an SCC
                if (v.minima_distanza == v.indice)
                {
                    Nodo w = null;
                    var component = new List<Nodo>();

                    while (v != w)
                    {
                        w = S.Pop();
                        w.discovered = 0;

                        component.Add(w);
                    }

                    SCC.Add(component);
                }
            };

            Sbianca();
            foreach (var v in V)
                if (v.indice < 0)
                    StrongConnect(v);

            return SCC;
        }

        public void Dijkstra(dynamic partenza)
        {
            Dijkstra(get_nodo(partenza));
        }


        // da perfezionare?
        public void Dijkstra(Nodo partenza)
        {
            Nodo u = null;
            var Q = new HashSet<Nodo>();

            foreach (var v in V)
            {
                v.distance = int.MaxValue;
                v.Pred = null;
                Q.Add(v);
            }

            partenza.distance = 0;

            while (Q.Count > 0)
            {
                foreach (var q in Q)
                    if (q.distance.CompareTo(u.distance) > 0)
                        u = q;

                Q.Remove(u);

                foreach (var v in Adj[u])
                {
                    var alt = u.distance + 1;

                    if (alt < v.distance)
                    {
                        v.distance = alt;
                        v.Pred = u;
                    }
                }
            }
        }

        private void ScriviFileDot(string nome_clean, string file)
        {
            //digraph G {a -> b;b -> c;a -> c;}

            using (var sw = new System.IO.StreamWriter(file, false))
            {
                sw.WriteLine("digraph " + nome_clean + " {");

                foreach (var v in V)
                    foreach (var e in Adj[v])
                        sw.WriteLine(v.N + " -> " + e.N + ";");

                sw.WriteLine("}");
                sw.Close();
            }
        }

        public void VediInFinestra()
        {
            var nome_clean = Nome.Replace(" ", "");

            var p = System.Reflection.Assembly.GetExecutingAssembly().Location;
            p = System.IO.Path.GetDirectoryName(p);

            var dot = System.IO.Path.Combine(p, "graphviz");
            var file = System.IO.Path.Combine(dot, nome_clean + ".dot");
            var visualizzatore = System.IO.Path.Combine(p, "Visualizzatore.exe");

            ScriviFileDot(nome_clean, file);

            System.IO.Directory.SetCurrentDirectory(dot);
            var par = "-Tsvg " + nome_clean + ".dot -o " + nome_clean + ".svg";
            System.Diagnostics.Process.Start("dot", par).WaitForExit();

            System.Diagnostics.Process.Start(visualizzatore, nome_clean + ".svg");
        }

        public eIntervallo ControllaIntervallo(dynamic a, dynamic b, dynamic x, dynamic y)
        {
            if (a < x && b < y)
                return eIntervallo.Disgiunto;
            else if (x < a && y < b)
                return eIntervallo.Disgiunto;
            else if (x < a && b < y)
                return eIntervallo.Contenuto;
            else if (a < x && y < b)
                return eIntervallo.Contiene;
            else
                throw new NotImplementedException();
        }


    }
}