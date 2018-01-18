/*
Copyright (C) 2015 [MAIONE MIKY]
This program is free software: you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation, either version 3 of the License, or (at your option) any later version. 
This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU General Public License for more details. 
You should have received a copy of the GNU General Public License along with this program. If not, see http://www.gnu.org/licenses/. 
*/
namespace Ordinamenti
{
    public class QuickSort_Nico_Lomuto
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
                Quicksort(A, l, p - 1);
                Quicksort(A, p + 1, r);
            }
        }

        private static int Partition(int[] A, int l, int r) // Θ(n)
        {
            pivot = A[r];
            i = l - 1;

            for (j = l; j < r; j++)
                if (A[j] <= pivot)
                    Swap(A, i += 1, j);

            Swap(A, i += 1, r);

            return i;
        }

        private static void Swap(int[] A, int x, int y)
        {
            if (x == y)
                return;

            temp = A[x];
            A[x] = A[y];
            A[y] = temp;
        }


    }
}