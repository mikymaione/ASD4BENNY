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
    class Program
    {

        static void Main(string[] args)
        {
            Main_20170224_2(args);
        }

        static void MainAlgo_MarcoErnestoFiorillo(string[] args)
        {
            //var n = new int[] { 8, 3, 10, 1, 6, 4, 7, 14, 13 };
            var n = new int[] { 50, 66, 25, 12, 8, 1, 7, 70, 55, 68, 32, 51, 58, 97, 81, 28, 30, 31, 63, 67, 71, 82, 98, 99 };

            var T1 = new BST(n);
            var T2 = new BST(n);

            Console.WriteLine("\nT1:");
            Esercizi.Algo_MarcoErnestoFiorillo(T1);


            Console.WriteLine("\nT2:");
            Esercizi.Algo_MarcoErnestoFiorillo_I(T2);
        }

        static void Main20171016(string[] args)
        {
            //var n = new int[] { 8, 3, 10, 1, 6, 4, 7, 14, 13 };
            var n = new int[] { 50, 66, 25, 12, 8, 1, 7, 70, 55, 68, 32, 51, 58, 97, 81, 28, 30, 31, 63, 67, 71, 82, 98, 99 };

            var T1 = new BST(n);
            var T2 = new BST(n);
            var a = 30;
            var b = 70;

            Console.WriteLine("\nT1:");
            //T1.Stampa();
            var ret1 = Esercizi.Algo_20171016(T1, a, b);
            Console.WriteLine("\nRet T1:");
            ret1?.Stampa();


            Console.WriteLine("\nT2:");
            //T2.Stampa();
            var ret2 = Esercizi.Algo_20171016_Miky(T2, a, b);
            Console.WriteLine("\nRet T2:");
            ret2?.Stampa();
        }

        static void Main20170718_2(string[] args)
        {
            //var n = new int[] { 8, 3, 10, 1, 6, 4, 7, 14, 13 };
            var n = new int[] { 50, 66, 25, 12, 8, 1, 7, 70, 55, 68, 32, 51, 58, 99, 81, 28, 30, 31, 63, 67, 0, 82, 100, 101 };

            var T1 = new BST(n);
            var T2 = new BST(n);
            var h = 6;

            var ret1 = Esercizi.Algo_20170718_2(T1, h);
            Console.WriteLine("\nT1:");
            T1.Stampa();
            Console.WriteLine("Ret: " + ret1);

            var ret2 = Esercizi.Algo_20170718_2_Miky(T2, h);
            Console.WriteLine("\nT2:");
            T2.Stampa();
            Console.WriteLine("Ret: " + ret2);
        }

        static void Main20170718_1(string[] args)
        {
            //var n = new int[] { 8, 3, 10, 1, 6, 4, 7, 14, 13 };
            var n = new int[] { 50, 66, 25, 12, 8, 1, 7, 70, 55, 68, 32, 51, 58, 99, 81, 28, 30, 31, 63, 67, 0, 82, 100, 101 };

            var T1 = new BST(n);
            var T2 = new BST(n);
            var k = 6;

            var ret1 = Esercizi.Algo_20170718_1(T1, k, null);
            Console.WriteLine("\nT1:");
            T1.Stampa();
            Console.WriteLine("Ret: " + ret1);

            var ret2 = Esercizi.Algo_20170718_1_Miky(T2, k, null);
            Console.WriteLine("\nT2:");
            T2.Stampa();
            Console.WriteLine("Ret: " + ret2);
        }

        static void MainInOrder_Ricorsivo(string[] args)
        {
            var n = new int[] { 66, 25, 12, 8, 1, 7, 70, 55, 68, 32, 51, 58, 99, 81, 28, 30, 31, 63, 67, 0, 82, 100, 101 };

            var T1 = new BST(50);

            foreach (var i in n)
                T1.Inserisci(i);

            Console.WriteLine("InOrder_Ricorsivo");
            BST.InOrder_Ricorsivo(T1, (e) =>
                {
                    Console.WriteLine(e.Key);
                });

            Console.WriteLine("InOrder_Iterativo");
            BST.InOrder_Iterativo(T1, (e) =>
                {
                    Console.WriteLine(e.Key);
                });
        }

        static void MainEvenDepthRic(string[] args)
        {
            var n = new int[] { 8, 3, 10, 1, 6, 4, 7, 14, 13 };
            //var n = new int[] { 50, 66, 25, 12, 8, 1, 7, 70, 55, 68, 32, 51, 58, 99, 81, 28, 30, 31, 63, 67, 0, 82, 100, 101 };
            var T1 = new BST(n);

            var ret = Esercizi.EvenDepthRic(T1);
            var ret2 = Esercizi.EvenDepthRic_Miky(T1);

            Console.WriteLine("EvenDepthRic R: " + ret);
            Console.WriteLine("EvenDepthRic I: " + ret2);
        }

        static void Main20170628_2_2_RND(string[] args)
        {
            var rnd = new Random(DateTime.Now.Second);
            var max = rnd.Next(10, 500);
            var N = new List<int>();

            for (var i = 0; i < max; i++)
                N.Add(rnd.Next(0, 999));

            var T1 = new BST(N);
            var T2 = new BST(N);

            var a = 5;
            var b = 12;

            Esercizi.Algo_20170628_2_2(T1, a, b);
            Console.WriteLine("\nT1:");
            T1.Stampa();

            Esercizi.Algo_20170628_2_2_Miky(T2, a, b);
            Console.WriteLine("\nT2:");
            T2.Stampa();
        }

        static void MainAlgo_Inventato1(string[] args)
        {
            //var n = new int[] { 8, 3, 10, 1, 6, 4, 7, 14, 13 };
            var n = new int[] { 50, 66, 25, 12, 8, 1, 7, 70, 55, 68, 32, 51, 58, 99, 81, 28, 30, 31, 63, 67, 0, 82, 100, 101 };

            var T1 = new BST(n);
            var T2 = new BST(n);

            var ret1 = Esercizi.Algo_Inventato1(T1);
            Console.WriteLine("\nT1:");
            Console.WriteLine("Ret: " + ret1);

            var ret2 = Esercizi.Algo_Inventato1_Miky(T2);
            Console.WriteLine("\nT2:");
            Console.WriteLine("Ret: " + ret2);
        }

        static void Main20170628_2_1(string[] args)
        {
            //var n = new int[] { 8, 3, 10, 1, 6, 4, 7, 14, 13 };
            var n = new int[] { 50, 66, 25, 12, 8, 1, 7, 70, 55, 68, 32, 51, 58, 99, 81, 28, 30, 31, 63, 67, 0, 82, 100, 101 };

            var T1 = new BST(n);
            var T2 = new BST(n);

            var ret1 = Esercizi.Algo_20170628_2_1(T1.dx, T1);
            Console.WriteLine("\nT1:");
            T1.Stampa();
            Console.WriteLine("Ret: " + ret1);

            var ret2 = Esercizi.Algo_20170628_2_1_Miky(T2.dx, T2);
            Console.WriteLine("\nT2:");
            T2.Stampa();
            Console.WriteLine("Ret: " + ret2);
        }

        static void Main20170628_2_2(string[] args)
        {
            //var n = new int[] { 8, 3, 10, 1, 6, 4, 7, 14, 13 };
            var n = new int[] { 50, 66, 25, 12, 8, 1, 7, 70, 55, 68, 32, 51, 58, 99, 81, 28, 30, 31, 63, 67, 0, 82, 100, 101 };

            var T1 = new BST(n);
            var T2 = new BST(n);

            var a = 30;
            var b = 100;

            Esercizi.Algo_20170628_2_2(T1, a, b);
            Console.WriteLine("\nT1:");
            T1.Stampa();

            Esercizi.Algo_20170628_2_2_Miky(T2, a, b);
            Console.WriteLine("\nT2:");
            T2.Stampa();
        }

        static void Main20170628_2_2simple(string[] args)
        {
            //var n = new int[] { 8, 3, 10, 1, 6, 4, 7, 14, 13 };
            var n = new int[] { 50, 66, 25, 12, 8, 1, 7, 70, 55, 68, 32, 51, 58, 99, 81, 28, 30, 31, 63, 67, 0, 82, 100, 101 };

            var T1 = new BST(n);
            var T2 = new BST(n);

            var a = 6;
            var b = 12;

            Esercizi.Algo_20170628_2_2simple(T1, a, b);
            Console.WriteLine("\nT1:");
            T1.Stampa();

            Esercizi.Algo_20170628_2_2simpleMiky(T2, a, b);
            Console.WriteLine("\nT2:");
            T2.Stampa();
        }

        static void Main_20170224_2(string[] args)
        {
            var x = 25;
            //var n = new int[] { 8, 3, 10, 1, 6, 4, 7, 14, 13 };
            var n = new int[] { 50, 66, 25, 12, 8, 2, 7, 70, 55, 68, 32, 51, 58, 98, 81, 28, 30, 31, 63, 67, 1, 82, 99, 100 };

            var T1 = new BST(n);
            var T2 = new BST(n);
            
            Console.WriteLine("Ricorsivo:");
            var ret = Esercizi.Algo_20170224_2(T1, null, x);

            Console.WriteLine("Iterativo:");
            var ret2 = Esercizi.Algo_20170224_2_Miky(T2, T2, x);
        }

        static void MainCountOddRic(string[] args)
        {
            var rnd = new Random(DateTime.Now.Second);
            var max = rnd.Next(10, 500);
            var T = new BST(rnd.Next(0, 999));

            for (var i = 0; i < max; i++)
                T.Inserisci(rnd.Next(0, 999));

            T.Stampa();

            Console.WriteLine("CountOddRic");
            var ret = Esercizi.CountOddRic(T);
            Console.WriteLine($"ret: {ret}");

            //Console.WriteLine("CountOddRic_Alunno");
            //var ret_alunno = Esercizi.CountOddRic_Alunno(T);
            //Console.WriteLine($"ret: {ret_alunno}");

            Console.WriteLine("CountOddRic_Miky");
            var ret_miky = Esercizi.CountOddRic_Miky(T);
            Console.WriteLine($"ret: {ret_miky}");
        }

        static void MainCountOddRic2(string[] args)
        {
            var n = new int[] { 3, 10, 1, 6, 4, 7, 14, 13 };
            var T = new BST(8);

            foreach (var i in n)
                T.Inserisci(i);

            T.Stampa();

            Console.WriteLine("CountOddRic");
            var ret = Esercizi.CountOddRic(T);
            Console.WriteLine($"ret: {ret}");

            Console.WriteLine("CountOddRic_Miky");
            var ret_miky = Esercizi.CountOddRic_Miky(T);
            Console.WriteLine($"ret: {ret_miky}");
        }

        static void MainTrovaChiavePiuVicina(string[] args)
        {
            var n = new int[] { 3, 10, 1, 6, 4, 7, 14, 13 };
            var T = new BST(8);

            foreach (var i in n)
                T.Inserisci(i);

            T.Stampa();

            for (var k = -2; k < 16; k++)
            {
                var chiave = T.TrovaChiavePiuVicina(k);
                Console.WriteLine($"Chiave più vicina a {k}: {chiave.Key}");
            }
        }


    }
}