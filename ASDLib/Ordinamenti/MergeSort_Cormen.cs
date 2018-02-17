/*
Copyright (C) 2015 [MAIONE MIKY]
This program is free software: you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation, either version 3 of the License, or (at your option) any later version. 
This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU General Public License for more details. 
You should have received a copy of the GNU General Public License along with this program. If not, see http://www.gnu.org/licenses/. 
*/
using System;

namespace Ordinamenti
{
    public class MergeSort_Cormen
    {
        private static int k, l, r, maxL, maxR;
        private static int[] L, R;

        public static void Sort(int[] A)
        {
            Mergesort(A, 1, A.Length);
        }

        private static void Mergesort(int[] A, int inizio, int fine)
        {
            if (inizio < fine)
            {
                var centro = (inizio + fine) / 2;
                Mergesort(A, inizio, centro);
                Mergesort(A, centro + 1, fine);
                Merge(A, inizio, centro, fine);
            }
        }

        private static void Merge(int[] A, int inizio, int centro, int fine)
        {
            l = 0;
            r = 0;

            maxL = centro - inizio + 1;
            maxR = fine - centro;

            L = new int[maxL + 1];
            R = new int[maxR + 1];

            L[maxL] = int.MaxValue;
            R[maxR] = int.MaxValue;

            Array.Copy(A, inizio - 1, L, 0, maxL);
            Array.Copy(A, centro, R, 0, maxR);

            for (k = inizio - 1; k < fine; k++)
                if (L[l] <= R[r])
                {
                    A[k] = L[l];
                    l++;
                }
                else
                {
                    A[k] = R[r];
                    r++;
                }
        }


    }
}