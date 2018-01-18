/*
Copyright (C) 2015 [MAIONE MIKY]
This program is free software: you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation, either version 3 of the License, or (at your option) any later version. 
This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU General Public License for more details. 
You should have received a copy of the GNU General Public License along with this program. If not, see http://www.gnu.org/licenses/. 
*/
using System.Collections.Generic;

namespace Alberi
{
    class Esercizi_20170224 : BST
    {

        public Esercizi_20170224(int k) : base(k) { }


        public static int Algo(BST T, BST P, int x)
        {
            var ret = 0;

            if (T != null)
            {
                var r_sx = Algo(T.sx, T, x);
                var r_dx = Algo(T.dx, T, x);

                ret = r_sx + r_dx + 1;
                System.Console.WriteLine($"n: {T.key} | ret: {ret}");

                if (T.key % 2 == 0 && ret < x && P != null)
                {
                    if (T == P.dx)
                        P.dx = Cancella(T);
                    else
                        P.sx = Cancella(T);
                }
            }

            return ret;
        }

        public static int Algo_Miky(BST T, BST P, int x)
        {
            BST last = null;
            var S = new Stack<BST>();

            var R = new Stack<int>();
            var n_figli = new Stack<bool[]>();
            var ret = 0;

            while (S.Count > 0 || T != null)
                if (T != null)
                {
                    n_figli.Push(new bool[] {
                        (T.Sx == null ? false : true),
                        (T.Dx == null ? false : true)
                    });

                    S.Push(T);
                    T = T.Sx;
                }
                else
                {
                    T = S.Peek();

                    if (T.Dx != null && T.Dx != last)
                        T = T.Dx;
                    else
                    {
                        S.Pop();
                        P = (S.Count > 0 ? S.Peek() : null);

                        var figli = n_figli.Pop();
                        var r_sx = (figli[0] ? R.Pop() : 0);
                        var r_dx = (figli[1] ? R.Pop() : 0);

                        ret = r_sx + r_dx + 1;
                        System.Console.WriteLine($"n: {T.key} | ret: {ret}");

                        R.Push(ret);
                        last = T;

                        if (T.key % 2 == 0 && ret < x && P != null)
                        {
                            if (T == P.dx)
                            {
                                P.dx = Cancella(T);
                                last = P.dx;
                            }
                            else
                            {
                                P.sx = Cancella(T);
                                last = P.sx;
                            }
                        }

                        T = null;
                    }
                }

            return ret;
        }


    }
}