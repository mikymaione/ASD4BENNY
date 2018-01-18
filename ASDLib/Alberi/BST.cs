/*
Copyright (C) 2015 [MAIONE MIKY]
This program is free software: you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation, either version 3 of the License, or (at your option) any later version. 
This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU General Public License for more details. 
You should have received a copy of the GNU General Public License along with this program. If not, see http://www.gnu.org/licenses/. 
*/
using System;
using System.Collections.Generic;

namespace Alberi
{
    public class BST
    {

        public BST dx, sx;
        public int key;

        public BST Dx
        {
            get
            {
                return dx;
            }
        }

        public BST Sx
        {
            get
            {
                return sx;
            }
        }

        public int Key
        {
            get
            {
                return key;
            }
        }

        public int Count
        {
            get
            {
                return (sx?.Count + 1 ?? 0) + (dx?.Count + 1 ?? 0);
            }
        }

        public BST(List<int> foglie)
        {
            var x = -1;

            foreach (var f in foglie)
            {
                x++;

                if (x == 0)
                    key = f;
                else
                    Inserisci(f);
            }
        }

        public BST(int[] foglie)
        {
            key = foglie[0];

            for (int i = 1; i < foglie.Length; i++)
                Inserisci(foglie[i]);
        }

        public BST(int k)
        {
            key = k;
        }

        public void Inserisci(int k)
        {
            if (k > key)
            {
                if (dx == null)
                    dx = new BST(k);
                else
                    dx.Inserisci(k);
            }
            else
            {
                if (sx == null)
                    sx = new BST(k);
                else
                    sx.Inserisci(k);
            }
        }

        public BST TrovaChiavePiuVicina(int k)
        {
            var chosen_k = this;
            var queue = new Queue<BST>();

            queue.Enqueue(this);

            while (queue.Count > 0)
            {
                var cur_n = queue.Dequeue();

                if (chosen_k.key == k || (cur_n.key != k && Math.Abs(cur_n.key - k) < Math.Abs(chosen_k.key - k)))
                    chosen_k = cur_n;

                if (cur_n.sx != null)
                    queue.Enqueue(cur_n.sx);

                if (cur_n.dx != null)
                    queue.Enqueue(cur_n.dx);
            }

            return chosen_k;
        }

        public BST Minimo
        {
            get
            {
                return sx?.Minimo ?? this;
            }
        }

        public BST Massimo
        {
            get
            {
                return dx?.Massimo ?? this;
            }
        }

        public static BST Successore(BST T, BST k, BST P = null)
        {
            if (T != null)
            {
                if (k.key > T.key)
                    return Successore(T.dx, k, P);
                else if (k.key < T.key)
                    return Successore(T.sx, k, T);
                else if (T.dx != null)
                    return T.Dx.Minimo;
            }

            return P;
        }

        private static BST StaccaMin(BST Padre, BST t)
        {
            if (t != null)
            {
                if (t.sx != null)
                {
                    return StaccaMin(t, t.sx);
                }
                else
                {
                    if (t == Padre.sx)
                        Padre.sx = t.dx;
                    else
                        Padre.dx = t.dx;
                }
            }

            return t;
        }

        public static BST Cancella(BST T)
        {
            if (T != null)
            {
                Console.WriteLine($"Cancello {T.key}");

                if (T.Dx == null)
                {
                    T = T.sx;
                }
                else if (T.Sx == null)
                {
                    T = T.Dx;
                }
                else
                {
                    var temp = StaccaMin(T, T.Dx);
                    T.key = temp.key;
                }
            }

            return T;
        }

        public static BST Cancella(BST Tree, BST k)
        {
            if (Tree != null)
            {
                if (Tree.key > k.key)
                    Tree.sx = BST.Cancella(Tree.sx, k);
                else if (Tree.key < k.key)
                    Tree.dx = BST.Cancella(Tree.dx, k);
                else
                {
                    var nodo = Tree;

                    if (nodo.dx == null)
                        Tree = nodo.sx;
                    else if (nodo.sx == null)
                        Tree = nodo.dx;
                    else
                    {
                        nodo = StaccaMin(Tree, Tree.dx);
                        Tree.key = nodo.key;
                    }
                }
            }

            return Tree;
        }

        private struct Pair
        {
            public BST n, P;

            public Pair(BST P_, BST n_)
            {
                P = P_;
                n = n_;
            }
        }

        public List<int> Cancella(int k1, int k2)
        {
            var A = new List<int>();
            var queue = new Queue<Pair>();
            var Tree = this;

            queue.Enqueue(new Pair(null, this));

            while (queue.Count > 0)
            {
                var cur = queue.Dequeue();

                if (cur.n.key >= k1 && cur.n.key <= k2)
                {
                    A.Add(cur.n.key);
                    BST.Cancella(Tree, cur.n);
                    queue.Enqueue(cur);
                }

                if (cur.n.sx != null)
                    queue.Enqueue(new Pair(cur.n, cur.n.sx));

                if (cur.n.dx != null)
                    queue.Enqueue(new Pair(cur.n, cur.n.dx));
            }

            return A;
        }

        public static void PreOrder_Ricorsivo(BST T, Action<BST> Action_PreOrder)
        {
            if (T != null)
            {
                Action_PreOrder(T);
                PreOrder_Ricorsivo(T.Sx, Action_PreOrder);
                PreOrder_Ricorsivo(T.Dx, Action_PreOrder);
            }
        }

        public static void InOrder_Ricorsivo(BST T, Action<BST> Action_InOrder)
        {
            if (T != null)
            {
                InOrder_Ricorsivo(T.Sx, Action_InOrder);
                Action_InOrder(T);
                InOrder_Ricorsivo(T.Dx, Action_InOrder);
            }
        }

        public static void PostOrder_Ricorsivo(BST T, Action<BST> Action_PreOrder, Action<BST> Action_InOrder, Action<BST> Action_PostOrder)
        {
            if (T != null)
            {
                Action_PreOrder(T);
                PostOrder_Ricorsivo(T.Sx, Action_PreOrder, Action_InOrder, Action_PostOrder);
                Action_InOrder(T);
                PostOrder_Ricorsivo(T.Dx, Action_PreOrder, Action_InOrder, Action_PostOrder);
                Action_PostOrder(T);
            }
        }

        public static void PreOrder_Iterativo(BST T, Action<BST> Action_PreOrder)
        {
            var S = new Stack<BST>();

            while (S.Count > 0 || T != null)
                if (T != null)
                {
                    Action_PreOrder(T);
                    S.Push(T);
                    T = T.Sx;
                }
                else
                {
                    T = S.Peek();
                    T = T.Dx;
                    S.Pop();
                }
        }

        public static void PostOrder_Iterativo(BST T, Action<BST> Action_PreOrder, Action<BST> Action_InOrder, Action<BST> Action_PostOrder)
        {
            BST last = null;
            var S = new Stack<BST>();

            while (S.Count > 0 || T != null)
                if (T != null)
                {
                    Action_PreOrder(T);

                    S.Push(T);
                    T = T.Sx;
                }
                else
                {
                    T = S.Peek();

                    if (T.Dx != null && T.Dx != last)
                    {
                        Action_InOrder(T);

                        T = T.Dx;
                    }
                    else
                    {
                        Action_PostOrder(T);

                        last = T;
                        T = null;
                        S.Pop();
                    }
                }
        }

        public static void PostOrder_Bene(BST T, Action<BST, BST, BST> Action_PreOrder_last_curr_next, Action<BST, BST, BST> Action_InOrder_last_curr_next, Action<BST, BST, BST> Action_PostOrder_last_curr_next)
        {
            BST last = null;
            BST next = null;
            BST curr = T;
            var S = new Stack<BST>();

            while (S.Count > 0 || curr != null)
            {
                if (curr != null)
                {
                    //discesa sx
                    S.Push(curr);
                    next = curr.Sx;

                    Action_PreOrder_last_curr_next(last, curr, next);
                }
                else
                {
                    curr = S.Peek(); //risalita

                    if (curr.Dx != null && curr.Dx != last)
                    {
                        //discesa a dx
                        next = curr.Dx;

                        Action_InOrder_last_curr_next(last, curr, next);
                    }
                    else
                    {
                        //risale da dx o da dx vuoto
                        next = null;
                        S.Pop();

                        Action_PostOrder_last_curr_next(last, curr, next);
                    }
                }

                last = curr; //applica operazione di discesa
                curr = next; //o di risalita
            }
        }

        public static void InOrder_Iterativo(BST T, Action<BST> Action_InOrder)
        {
            var S = new Stack<BST>();

            while (S.Count > 0 || T != null)
                if (T != null)
                {
                    S.Push(T);
                    T = T.Sx;
                }
                else
                {
                    T = S.Pop();
                    Action_InOrder(T);
                    T = T.Dx;
                }
        }

        public void Stampa(int indentazione = 0)
        {
            sx?.Stampa(indentazione + 1);

            for (int i = 0; i < indentazione; i++)
                Console.Write("-");

            if (key < 10)
                Console.Write("0");

            Console.WriteLine($"{Key}");

            dx?.Stampa(indentazione + 1);
        }


    }
}