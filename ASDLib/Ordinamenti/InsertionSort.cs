/*
Copyright (C) 2015 [MAIONE MIKY]
This program is free software: you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation, either version 3 of the License, or (at your option) any later version. 
This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU General Public License for more details. 
You should have received a copy of the GNU General Public License along with this program. If not, see http://www.gnu.org/licenses/. 
*/
namespace Ordinamenti
{
    public class InsertionSort
    {

        public static void Sort(int[] A)
        {
            for (var j = 0; j < A.Length; j++)
            {
                var K = A[j];
                var i = j - 1;

                while (i > -1 && A[i] > K)
                {
                    A[i + 1] = A[i];
                    i--;
                }

                A[i + 1] = K;
            }
        }


    }
}