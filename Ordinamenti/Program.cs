/*
Copyright (C) 2015 [MAIONE MIKY]
This program is free software: you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation, either version 3 of the License, or (at your option) any later version. 
This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU General Public License for more details. 
You should have received a copy of the GNU General Public License along with this program. If not, see http://www.gnu.org/licenses/. 
*/
using System;

namespace Ordinamenti
{
    class Program
    {

        private static Random rnd = new Random(DateTime.Now.Second);

        static void QSTH()
        {
            var A = new int[] { 1, 9, 3, 4, 6, 5, 7, 8, 2 };
            var B = new int[] { 9, 1, 7, 6, 5, 4, 3, 2, 8 };
            var C = RandomArray(37);
            var D = new int[] { 5, 4, 3, 2, 1 };

            QuickSort_Tony_Hoare.Sort(A);
            QuickSort_Tony_Hoare.Sort(B);
            QuickSort_Tony_Hoare.Sort(C);
            QuickSort_Tony_Hoare.Sort(D);

            Stampa("A", A);
            Stampa("B", B);
            Stampa("C", C);
            Stampa("D", D);
        }

        static void QSNL()
        {
            var A = new int[] { 1, 9, 3, 4, 6, 5, 7, 8, 2 };
            var B = new int[] { 9, 1, 7, 6, 5, 4, 3, 2, 8 };
            var C = RandomArray(37);
            var D = new int[] { 5, 4, 3, 2, 1 };

            QuickSort_Nico_Lomuto.Sort(A);
            QuickSort_Nico_Lomuto.Sort(B);
            QuickSort_Nico_Lomuto.Sort(C);
            QuickSort_Nico_Lomuto.Sort(D);

            Stampa("A", A);
            Stampa("B", B);
            Stampa("C", C);
            Stampa("D", D);
        }

        static void Main(string[] args)
        {
            var A = new int[] { 1, 9, 3, 4, 6, 5, 7, 8, 2 };
            var B = new int[] { 9, 1, 7, 6, 5, 4, 3, 2, 8 };
            var C = RandomArray(37);
            var D = new int[] { 5, 4, 3, 2, 1 };

            QSNL();
            QSTH();

            //InsertionSort.Sort(A);
            //InsertionSort.Sort(B);
            //MergeSort_Cormen.Sort(A);
            //MergeSort_Cormen.Sort(B);
            //MergeSort_Cormen.Sort(C);

            //MergeSort_Cormen.Sort(A);
            //MergeSort_Cormen.Sort(B);
            //MergeSort_Cormen.Sort(C);         

            /*
            var X = new int[] { 4, 5, 6, 1, 2, 3, 8, 9, 0, 7 };
            Stampa("X", X);
            var heap = new Heap(X);
            heap.BuildMaxHeap();
            Stampa("Heap di X", heap.array);

            var Y = RandomArray(30);
            Stampa("Y", Y);
            var heap2 = new Heap(Y);
            heap2.HeapSort();
            Stampa("HeapSort di Y", heap2.array);

            var Z = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            Stampa("Z", X);
            var heap3 = new Heap(Z);
            heap3.BuildMaxHeap();
            Stampa("Heap di Z", heap3.array);
            */
        }

        static int[] RandomArray(int n)
        {
            var A = new int[n];

            for (var i = 0; i < n; i++)
                A[i] = rnd.Next(0, 99);

            return A;
        }

        static void Stampa(string nome, int[] A)
        {
            Console.Write(nome + ": ");

            var s = "";
            foreach (var i in A)
                s += i + " ";

            Console.WriteLine(s);
        }


    }
}