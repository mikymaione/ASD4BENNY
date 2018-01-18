/*
Copyright (C) 2015 [MAIONE MIKY]
This program is free software: you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation, either version 3 of the License, or (at your option) any later version. 
This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU General Public License for more details. 
You should have received a copy of the GNU General Public License along with this program. If not, see http://www.gnu.org/licenses/. 
*/
namespace Ordinamenti
{
    public class QuickSort_Tony_Hoare
    {

        private static int temp, pivot, i, j, p;

        public static void Sort(int[] A) // Θ(n log n) → Θ(n²)
        {
            Quicksort(A, 0, A.Length - 1);
        }

        private static void Quicksort(int[] A, int l, int r) // Θ(n log n) → Θ(n²)
        {
            if (l < r)
            {
                p = Partition(A, l, r);
                Quicksort(A, l, p);
                Quicksort(A, p + 1, r);
            }
        }

        private static int Partition(int[] A, int lo, int hi) // Θ(n)
        {
            pivot = A[lo];
            i = lo - 1;
            j = hi + 1;

            while (true)
            {
                do
                {
                    i++;
                } while (A[i] < pivot);

                do
                {
                    j--;
                } while (A[j] > pivot);

                if (i >= j)
                    return j;

                Swap(A, i, j);
            }
        }

        private static void Swap(int[] A, int x, int y)
        {
            temp = A[x];
            A[x] = A[y];
            A[y] = temp;
        }


    }
}