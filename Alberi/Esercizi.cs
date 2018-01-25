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
    sealed class Esercizi : BST
    {

        public Esercizi(int k) : base(k) { }

        public static int Algo_20170224_2(BST T, BST P, int x)
        {
            if (T == null)
                return 0;

            var r_sx = Algo_20170224_2(T.sx, T, x);
            var r_dx = Algo_20170224_2(T.dx, T, x);
            var ret = r_sx + r_dx + 1;

            Console.WriteLine($"n: {T.key} | r_sx: {r_sx} r_dx: {r_dx} ret: {ret}");

            if (T.key % 2 == 0 && ret < x && P != null)
            {
                if (T == P.dx)
                    P.dx = Cancella(T);
                else
                    P.sx = Cancella(T);
            }

            return ret;
        }

        //aggiustato da me e funziona!
        public static int Algo_20170224_2_CiroMart(BST T, BST P, int x)
        {
            BST last = null;
            BST next = null;
            BST curr = T;
            var S = new Stack<BST>();

            var S_RET = new Stack<int>();
            var r_sx = 0;
            var r_dx = 0;
            var ret = 0;

            var ero_destro = false;

            while (S.Count > 0 || curr != null)
            {
                if (curr != null)
                {
                    //discesa sx
                    S.Push(curr);
                    next = curr.Sx;

                    ret = 0;
                }
                else
                {
                    curr = S.Peek(); //risalita

                    if (curr.Dx != null && curr.Dx != last)
                    {
                        //discesa a dx
                        next = curr.Dx;

                        S_RET.Push(ret);
                        r_sx = ret;
                        ret = 0;
                    }
                    else
                    {
                        //risale da dx o da dx vuoto
                        next = null;
                        S.Pop();

                        P = (S.Count > 0 ? S.Peek() : null);                        

                        if (ero_destro)
                        {
                            r_sx = S_RET.Pop();
                            r_dx = ret;
                        }
                        else
                        {
                            r_sx = ret;
                            r_dx = 0;
                        }

                        ero_destro = (curr == P?.dx);

                        ret = r_sx + r_dx + 1;

                        Console.WriteLine($"n: {curr.key} | r_sx: {r_sx} r_dx: {r_dx} ret: {ret}");

                        if (curr.key % 2 == 0 && ret < x && P != null)
                        {
                            if (curr == P.dx)
                            {
                                curr = Cancella(curr);
                                P.dx = curr;
                            }
                            else
                            {
                                curr = Cancella(curr);
                                P.sx = curr;
                            }
                        }
                    }
                }

                last = curr; //applica operazione di discesa
                curr = next; //o di risalita                
            }

            return ret;
        }        

        public static void Algo_MarcoErnestoFiorillo(BST T)
        {
            if (T != null)
            {
                var a = 2;
                var b = 25;
                Console.WriteLine($" T: {T.key}, a: {a}, b: {b}");

                Algo_MarcoErnestoFiorillo(T.sx);
                a = a * T.key;

                Algo_MarcoErnestoFiorillo(T.dx);
                b = b + T.key;

                if (a % b == 0)
                    Console.WriteLine($"!T: {T.key}, a: {a}, b: {b}");
                else
                    Console.WriteLine($"?T: {T.key}, a: {a}, b: {b}");
            }
        }

        public static void Algo_MarcoErnestoFiorillo_I(BST T)
        {
            BST last = null;
            BST next = null;
            BST curr = T;
            var S = new Stack<BST>();

            var Sa = new Stack<int>();
            var Sb = new Stack<int>();

            while (S.Count > 0 || curr != null)
            {
                if (curr != null)
                {
                    var a = 2;
                    var b = 25;

                    Sa.Push(a);
                    Sb.Push(b);
                    S.Push(curr);
                    next = curr.Sx;

                    Console.WriteLine($" T: {curr.key}, a: {a}, b: {b}");
                }
                else
                {
                    var a = Sa.Peek();
                    var b = Sb.Peek();
                    curr = S.Peek();

                    if (curr.Dx != null && curr.Dx != last)
                    {
                        next = curr.Dx;
                    }
                    else
                    {
                        a = a * curr.key;
                        b = b + curr.key;

                        if (a % b == 0)
                            Console.WriteLine($"!T: {curr.key}, a: {a}, b: {b}");
                        else
                            Console.WriteLine($"?T: {curr.key}, a: {a}, b: {b}");

                        next = null;
                        S.Pop();
                        Sa.Pop();
                        Sb.Pop();
                    }
                }

                last = curr;
                curr = next;
            }
        }

        public static BST Algo_20171016(BST T, int a, int b)
        {
            if (T != null)
            {
                Console.WriteLine($"T: {T.key}, a: {a}, b: {b}");

                if (T.key >= a && T.key <= b)
                {
                    T.sx = Algo_20171016(T.sx, a, T.key);
                    T.dx = Algo_20171016(T.dx, T.key, b);
                }
                else
                {
                    Cancella(T);
                    T = null;
                }
            }

            return T;
        }

        public static BST Algo_20171016_Miky(BST T, int a, int b)
        {
            BST last = null;
            BST next = null;
            BST curr = T;
            var S = new Stack<BST>();

            var Sa = new Stack<int>();
            var Sb = new Stack<int>();

            while (S.Count > 0 || curr != null)
            {
                if (curr != null)
                {
                    S.Push(curr);
                    Sa.Push(a);
                    Sb.Push(b);

                    Console.WriteLine($"T: {curr.key}, a: {a}, b: {b}");

                    if (curr.key >= a && curr.key <= b)
                    {
                        next = curr.Sx;
                        b = curr.key;
                    }
                    else
                    {
                        var sono_sinistro = curr.Equals(last.sx);

                        Cancella(curr);
                        curr = null;
                        next = null;
                        S.Pop();
                        Sa.Pop();
                        Sb.Pop();

                        if (sono_sinistro)
                            last.sx = null;
                        else
                            last.dx = null;
                    }
                }
                else
                {
                    curr = S.Peek();
                    a = Sa.Peek();
                    b = Sb.Peek();

                    if (curr.Dx != null && curr.Dx != last)
                    {
                        if (curr.key >= a && curr.key <= b)
                        {
                            next = curr.Dx;
                            a = curr.key;
                        }
                    }
                    else
                    {
                        next = null;
                        S.Pop();
                        Sa.Pop();
                        Sb.Pop();
                    }
                }

                last = curr;
                curr = next;
            }

            return T;
        }

        public static int Algo_20170718_2(BST T, int h)
        {
            if (T == null)
            {
                return -1;
            }
            else
            {
                // valori costanti di s & d ad ogni inizio di ricorsione
                var s = 5;
                var d = 3;
                Console.WriteLine("Ispezionando {0}: h:{1} s:{2} d:{3}", T.key, h, s, d);

                if (T.sx != null)
                    s = Algo_20170718_2(T.sx, h + 11);

                if (T.dx != null)
                    d = Algo_20170718_2(T.dx, h + 7);

                var ret =
                    (s == 5 && d == 3) ?
                    h :
                    s + d;

                Console.WriteLine("Ispezionando {0}: h:{1} s:{2} d:{3} ret:{4}", T.key, h, s, d, ret);

                return ret;
            }
        }

        public static int Algo_20170718_2_Miky(BST T, int h)
        {
            BST last = null;
            BST next = null;
            BST curr = T;
            var S = new Stack<BST>();

            var RET = -1;

            var S_s = new Stack<int>();
            var S_d = new Stack<int>();
            var S_h = new Stack<int>();

            S_h.Push(h);

            while (S.Count > 0 || curr != null)
            {
                if (curr != null)
                {
                    S.Push(curr);
                    next = curr.Sx;

                    // valori costanti di s & d ad ogni inizio di ricorsione
                    var temp_s = 5;
                    var temp_d = 3;
                    S_s.Push(temp_s);
                    S_d.Push(temp_d);

                    var temp_h_sx = S_h.Peek();
                    if (next != null)
                        S_h.Push(temp_h_sx += 11);

                    Console.WriteLine("Ispezionando {0}: h:{1} s:{2} d:{3}", curr.key, temp_h_sx, temp_s, temp_d);
                }
                else
                {
                    curr = S.Peek();

                    if (curr.Dx != null && curr.Dx != last)
                    {
                        next = curr.Dx;

                        var temp_h_dx = S_h.Peek();
                        if (next != null)
                            S_h.Push(temp_h_dx += 7);
                    }
                    else
                    {
                        next = null;
                        S.Pop();

                        var temp_h = S_h.Pop();
                        var temp_s = S_s.Pop();
                        var temp_d = S_d.Pop();

                        var temp_ret =
                            (temp_s == 5 && temp_d == 3) ?
                            temp_h :
                            temp_s + temp_d;

                        if (S.Count > 0)
                        {
                            if (curr == S.Peek().sx) // sono un sinitro
                            {
                                S_s.Pop();
                                S_s.Push(temp_ret);
                            }
                            else if (curr == S.Peek().dx) // sono un destro
                            {
                                S_d.Pop();
                                S_d.Push(temp_ret);
                            }
                        }

                        Console.WriteLine("Ispezionando {0}: h:{1} s:{2} d:{3} ret:{4}", curr.key, temp_h, temp_s, temp_d, temp_ret);
                        RET = temp_ret;
                    }
                }

                last = curr;
                curr = next;
            }

            return RET;
        }

        public static int Algo_20170718_1(BST T, int k, BST P)
        {
            var ret = -1;

            if (T != null)
            {
                Console.WriteLine("Ispezionando {0}", T.key);

                var h1 = Algo_20170718_1(T.sx, k, T);
                var h2 = h1 + Algo_20170718_1(T.dx, k, T);
                ret = h2 + 1;

                if (ret > k && P != null)
                {
                    if (T == P.dx)
                        P.dx = Cancella(T);
                    else
                        P.sx = Cancella(T);
                }

                Console.WriteLine("Ispezionando {0}: {1}", T.key, ret);
            }

            return ret;
        }

        public static int Algo_20170718_1_Miky(BST T, int k, BST P)
        {
            BST last = null;
            var S = new Stack<BST>();

            var SH1 = new Stack<int>();
            var SH2 = new Stack<int>();

            var ret = 0;

            while (S.Count > 0 || T != null)
                if (T != null)
                {
                    Console.WriteLine("Ispezionando {0}", T.key);

                    SH1.Push(-1);
                    SH2.Push(-1);

                    S.Push(T);
                    T = T.Sx;
                }
                else
                {
                    T = S.Peek();

                    if (T.Dx != null && T.Dx != last)
                    {
                        T = T.Dx;
                    }
                    else
                    {
                        S.Pop();
                        last = T;
                        P = (S.Count > 0 ? S.Peek() : null);

                        var h1 = SH1.Pop();
                        var h2 = h1 + SH2.Pop();
                        ret = h2 + 1;

                        if (P != null)
                        {
                            //+1 perché il nodo T esiste.
                            if (T == P.sx)
                                SH1.Push(1 + ret + SH1.Pop());
                            else
                                SH2.Push(1 + ret + SH2.Pop());
                        }

                        if (ret > k && P != null)
                        {
                            last = Cancella(T);

                            if (T == P.dx)
                                P.dx = last;
                            else
                                P.sx = last;
                        }

                        Console.WriteLine("Ispezionando {0}: {1}", T.key, ret);
                        T = null;
                    }
                }

            return ret;
        }

        public static int Algo_Inventato1(BST T)
        {
            var ret = 0;

            if (T != null)
            {
                Console.WriteLine("Ispezionando {0}", T.key);

                var x = Algo_Inventato1(T.Sx);
                x = x * 3;

                if (x % 2 == 0)
                {
                    var y = Algo_Inventato1(T.Dx);

                    if (y % 3 == 0)
                        ret = 7 + y + x;
                }
                else
                {
                    var y = Algo_Inventato1(T.Dx);

                    if (y % 7 == 0)
                        ret = 3 + y + x;
                }

                Console.WriteLine("Ispezionando {0} ret: {1}", T.key, ret);
            }

            return ret;
        }

        public static int Algo_Inventato1_Miky(BST T)
        {
            var ret = 0;
            var X = new Stack<int>();
            var Y = new Stack<int>();

            BST last = null;
            var S = new Stack<BST>();

            while (S.Count > 0 || T != null)
                if (T != null)
                {
                    Console.WriteLine("Ispezionando {0}", T.key);

                    X.Push(0);
                    Y.Push(0);

                    S.Push(T);
                    T = T.Sx;
                }
                else
                {
                    T = S.Peek();

                    if (T.Dx != null && T.Dx != last)
                    {
                        var x = X.Pop();
                        x = x * 3;
                        X.Push(x);

                        if (x % 2 == 0)
                        {
                            T = T.Dx;
                        }
                        else
                        {
                            T = T.Dx;
                        }
                    }
                    else
                    {
                        S.Pop();
                        var x = X.Pop();
                        var y = Y.Pop();

                        ret = 0;

                        if (x % 2 == 0)
                        {
                            if (y % 3 == 0)
                                ret = 7 + y + x;
                        }
                        else
                        {
                            if (y % 7 == 0)
                                ret = 3 + y + x;
                        }

                        if (S.Count > 0)
                        {
                            var P = S.Peek();

                            if (P.sx == T)
                                X.Push(ret + X.Pop());
                            else
                                Y.Push(ret + Y.Pop());
                        }

                        Console.WriteLine("Ispezionando {0} ret: {1}", T.key, ret);

                        last = T;
                        T = null;
                    }
                }

            return ret;
        }

        public static int Algo_20170628_2_1(BST T, BST P)
        {
            if (T == null)
                return 0;

            Console.WriteLine("Ispezionando {0}", T.key);

            var x = Algo_20170628_2_1(T.sx, T);
            var y = Algo_20170628_2_1(T.dx, T);

            var flag = (T.key % 2 == 0 ? 1 : 0);

            if (flag == 1 && P != null && x + y == 0)
            {
                if (P.sx == T)
                    P.sx = Cancella(T);
                else
                    P.dx = Cancella(T);
            }

            var ret = x + y + flag;

            Console.WriteLine("Ispezionando {0}: {1}", T.key, ret);

            return ret;
        }

        public static int Algo_20170628_2_1_Miky(BST Tree, BST Dad)
        {
            BST last = null;
            BST T = Tree;
            BST P = Dad;
            var S = new Stack<BST>();

            var RS = new Stack<int>();
            var RD = new Stack<int>();
            var RF = new Stack<int>();

            var ret = 0;

            while (S.Count > 0 || T != null)
                if (T != null)
                {
                    Console.WriteLine("Ispezionando {0}", T.key);

                    var flag = (T.key % 2 == 0 ? 1 : 0);

                    RF.Push(flag);
                    RS.Push(0);
                    RD.Push(0);

                    S.Push(T);
                    T = T.Sx;
                }
                else
                {
                    T = S.Peek();

                    if (T.Dx != null && T.Dx != last)
                    {
                        T = T.Dx;
                    }
                    else
                    {
                        S.Pop();
                        last = T;

                        var x = RS.Pop();
                        var y = RD.Pop();
                        var flag = RF.Pop();

                        ret = x + y + flag;

                        if (T == Tree)
                            P = Dad;
                        else if (S.Count > 0)
                        {
                            P = S.Peek();

                            if (T == P.dx)
                                RD.Push(ret + RD.Pop());
                            else
                                RS.Push(ret + RS.Pop());
                        }
                        else
                            P = null;

                        if (flag == 1 && P != null && x + y == 0)
                        {
                            var temp = Cancella(T);

                            if (P.sx == T)
                                P.sx = temp;
                            else
                                P.dx = temp;

                            last = temp;
                        }

                        Console.WriteLine("Ispezionando {0}: {1}", T.key, ret);
                        T = null;
                    }
                }

            return ret;
        }

        public static BST Algo_20170628_2_2_Miky(BST T, int a, int b)
        {
            BST last = null;
            var S = new Stack<BST>();

            while (S.Count > 0 || T != null)
            {
                if (T != null)
                {
                    Console.WriteLine("Ispezionando " + T.key);
                    S.Push(T);
                }

                if (T != null && (T.key < a || (T.key >= a && T.key <= b)))
                {
                    T = T.Sx;
                }
                else
                {
                    if (T == null)
                        T = S.Peek();

                    if (T.Dx != null && T.Dx != last && ((T.key > b) || (T.key >= a && T.key <= b)))
                    {
                        T = T.Dx;
                    }
                    else
                    {
                        S.Pop();
                        last = T;

                        if (T.key >= a && T.key <= b)
                        {
                            T = Cancella(T);

                            if (S.Count > 0)
                            {
                                var P = S.Peek();

                                if (P.dx == last)
                                    P.dx = T;
                                else if (P.sx == last)
                                    P.sx = T;
                            }

                            if (T != null)
                                last = T;
                        }

                        T = null;
                    }
                }
            }

            return last;
        }

        public static BST Algo_20170628_2_2(BST T, int a, int b)
        {
            if (T != null)
            {
                Console.WriteLine("Ispezionando " + T.key);

                if (T.key < a)
                    T.sx = Algo_20170628_2_2(T.sx, a, b);
                else if (T.key > b)
                    T.dx = Algo_20170628_2_2(T.dx, a, b);
                else
                {
                    T.sx = Algo_20170628_2_2(T.sx, a, b);
                    T.dx = Algo_20170628_2_2(T.dx, a, b);
                    T = Cancella(T);
                }
            }

            return T;
        }

        public static BST Algo_20170628_2_2simpleMiky(BST T, int a, int b)
        {
            BST last = null;
            var S = new Stack<BST>();

            while (S.Count > 0 || T != null)
                if (T != null)
                {
                    S.Push(T);
                    T = T.sx;
                }
                else
                {
                    T = S.Peek();

                    if (T.dx != null && T.dx != last)
                    {
                        T = T.Dx;
                    }
                    else
                    {
                        last = T;
                        S.Pop();

                        if (a < T.key && T.key < b)
                        {
                            T = Cancella(T);

                            if (S.Count > 0)
                            {
                                var P = S.Peek();

                                if (P.dx == last)
                                    P.dx = T;
                                else if (P.sx == last)
                                    P.sx = T;
                            }
                        }

                        T = null;
                    }
                }

            return last;
        }

        public static BST Algo_20170628_2_2simple(BST T, int a, int b)
        {
            if (T != null)
            {
                T.sx = Algo_20170628_2_2simple(T.sx, a, b);
                T.dx = Algo_20170628_2_2simple(T.dx, a, b);

                if (a < T.key && T.key < b)
                    T = Cancella(T);
            }

            return T;
        }


        private static int EvenDepthRic_Funzione(BST T, int dpsx, int dpdx)
        {
            var ret = -1;

            var maxdp = Math.Max(dpsx, dpdx);

            if (maxdp >= 0)
                maxdp++;

            if (T.Key % 2 == 0)
                ret = Math.Max(0, maxdp);
            else
                ret = maxdp;

            return ret;
        }

        public static int EvenDepthRic(BST T)
        {
            if (T == null)
                return -1;
            else
                return EvenDepthRic_Funzione(T, EvenDepthRic(T.Sx), EvenDepthRic(T.Dx));
        }

        public static int EvenDepthRic_Miky(BST T)
        {
            var ret = -1;
            var RS = new Stack<int>();

            PostOrder_Ricorsivo(T,
                (c) =>
                {
                },
                (c) =>
                {
                    if (c.Sx == null)
                        RS.Push(-1);
                    else
                        RS.Push(ret);
                },
                (c) =>
                {
                    var dpsx = RS.Pop();
                    var dpdx = (c.Dx == null ? -1 : ret);

                    ret = EvenDepthRic_Funzione(c, dpsx, dpdx);
                }
            );

            return ret;
        }

        //BENE STYLE
        public static int CountOddRic_Miky(BST T)
        {
            var ret = 0;
            var RR = new Stack<int>();
            var RS = new Stack<int>();

            PostOrder_Iterativo(T,
                (curr) =>
                {
                    ret = (curr.Key % 2 == 1 ? curr.Key : 0);
                    RR.Push(ret);

                    Console.WriteLine($"1- Ispezionando: {curr.Key} ret: {ret}");
                },
                (curr) =>
                {
                    if (curr.Sx != null)
                        RS.Push(ret);
                },
                (curr) =>
                {
                    var r_sx = 0;
                    var r_dx = 0;

                    if (curr.Sx != null && curr.Dx == null)
                        r_sx = ret;
                    else if (curr.Sx != null && curr.Dx != null)
                        r_sx = RS.Pop();

                    if (curr.Dx != null)
                        r_dx = ret;

                    ret = RR.Pop();

                    ret = ret + r_sx + r_dx;

                    Console.WriteLine($"2- Ispezionando: {curr.Key} ret: {ret}");
                }
            );

            return ret;
        }

        //BENE STYLE
        public static int CountOddRic_Miky_Prolisso(BST T)
        {
            BST last = null;
            var S = new Stack<BST>();
            var RR = new Stack<int>();
            var RS = new Stack<int>();
            var ret = 0;

            while (S.Count > 0 || T != null)
                if (T != null)
                {
                    ret = (T.Key % 2 == 1 ? T.Key : 0);
                    Console.WriteLine($"1- Ispezionando: {T.Key} ret: {ret}");

                    RR.Push(ret);
                    S.Push(T);
                    T = T.Sx;
                }
                else
                {
                    T = S.Peek();

                    if (T.Dx != null && T.Dx != last)
                    {
                        if (T.Sx != null)
                            RS.Push(ret);

                        T = T.Dx;
                    }
                    else
                    {
                        var r_sx = 0;
                        var r_dx = 0;

                        if (T.Sx != null && T.Dx == null)
                            r_sx = ret;
                        else if (T.Sx != null && T.Dx != null)
                            r_sx = RS.Pop();

                        if (T.Dx != null)
                            r_dx = ret;

                        ret = RR.Pop();

                        ret = ret + r_sx + r_dx;

                        Console.WriteLine($"2- Ispezionando: {T.Key} ret: {ret}");

                        last = T;
                        T = null;
                        S.Pop();
                    }
                }

            return ret;
        }

        // OK
        public static int CountOddRic_Miky9(BST T)
        {
            BST last = null;
            var S = new Stack<BST>();

            var ret = 0;
            var R = new Dictionary<BST, int>();

            while (S.Count > 0 || T != null)
                if (T != null)
                {
                    ret = (T.Key % 2 == 1 ? T.Key : 0);
                    Console.WriteLine($"1- Ispezionando: {T.Key} ret: {ret}");

                    R.Add(T, ret);

                    S.Push(T);
                    T = T.Sx;
                }
                else
                {
                    T = S.Peek();

                    if (T.Dx != null && T.Dx != last)
                    {
                        T = T.Dx;
                    }
                    else
                    {
                        var r_sx = (T.Sx != null && R.ContainsKey(T.Sx) ? R[T.Sx] : 0);
                        var r_dx = (T.Dx != null && R.ContainsKey(T.Dx) ? R[T.Dx] : 0);

                        ret = R[T];
                        ret = ret + r_sx + r_dx;

                        if (R.ContainsKey(T))
                            R[T] = ret;
                        else
                            R.Add(T, ret);

                        Console.WriteLine($"2- Ispezionando: {T.Key} ret: {ret}");

                        last = T;
                        T = null;
                        S.Pop();
                    }
                }

            return ret;
        }

        // OK
        public static int CountOddRic_Miky8(BST T)
        {
            var R = new Stack<int>();
            var S1 = new Stack<BST>();
            var S2 = new Stack<BST>();

            S1.Push(T);
            while (S1.Count > 0)
            {
                var node = S1.Pop();
                S2.Push(node);

                if (node.Sx != null)
                    S1.Push(node.Sx);
                if (node.Dx != null)
                    S1.Push(node.Dx);
            }

            while (S2.Count > 0)
            {
                T = S2.Pop();
                var ret = (T.Key % 2 == 1 ? T.Key : 0);

                var r_sx = 0;
                var r_dx = 0;

                if (T.Dx != null)
                    r_dx = R.Pop();
                if (T.Sx != null)
                    r_sx = R.Pop();

                ret = ret + r_sx + r_dx;
                R.Push(ret);

                Console.WriteLine($"4Ispezionando: {T.Key} ret: {ret}");
            }

            return R.Pop();
        }

        public static int CountOddRic(BST T)
        {
            var ret = 0;

            if (T != null)
            {
                ret = (T.Key % 2 == 1 ? T.Key : 0);
                Console.WriteLine($"1- Ispezionando: {T.Key} ret: {ret}");

                var r_sx = CountOddRic(T.Sx);
                var r_dx = CountOddRic(T.Dx);

                ret = ret + r_sx + r_dx;
                Console.WriteLine($"2- Ispezionando: {T.Key} ret: {ret}");
            }

            return ret;
        }


    }
}