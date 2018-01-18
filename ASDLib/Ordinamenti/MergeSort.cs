/*
Copyright (C) 2015 [MAIONE MIKY]
This program is free software: you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation, either version 3 of the License, or (at your option) any later version. 
This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU General Public License for more details. 
You should have received a copy of the GNU General Public License along with this program. If not, see http://www.gnu.org/licenses/. 
*/
namespace Ordinamenti
{
    public class MergeSort
    {

        public static void Sort(int[] A)
        {
            Mergesort(A, 0, A.Length - 1);
        }

        private static void Mergesort(int[] A, int startIndex, int endIndex)
        {
            if (endIndex > startIndex)
            {
                var mid = (endIndex + startIndex) / 2;
                Mergesort(A, startIndex, mid);
                Mergesort(A, (mid + 1), endIndex);
                Merge(A, startIndex, (mid + 1), endIndex);
            }
        }

        private static void Merge(int[] A, int left, int mid, int right)
        {
            //Merge procedure takes theta(n) time
            var B = new int[A.Length];
            var leftEnd = mid - 1;
            var k = left;
            var lengthOfInput = right - left + 1;

            //selecting smaller element from left sorted array or right sorted array and placing them in temp array.
            while ((left <= leftEnd) && (mid <= right))
            {
                if (A[left] <= A[mid])
                    B[k++] = A[left++];
                else
                    B[k++] = A[mid++];
            }

            //placing remaining element in temp from left sorted array
            while (left <= leftEnd)
                B[k++] = A[left++];

            //placing remaining element in temp from right sorted array
            while (mid <= right)
                B[k++] = A[mid++];

            //placing temp array to input
            for (var i = 0; i < lengthOfInput; i++)
            {
                A[right] = B[right];
                right--;
            }
        }


    }
}