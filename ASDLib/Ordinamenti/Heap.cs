/*
Copyright (C) 2015 [MAIONE MIKY]
This program is free software: you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation, either version 3 of the License, or (at your option) any later version. 
This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU General Public License for more details. 
You should have received a copy of the GNU General Public License along with this program. If not, see http://www.gnu.org/licenses/. 
*/
namespace Ordinamenti
{
    public class Heap
    {

        private int[] A;
        private int HeapSize_;


        public int[] array
        {
            get
            {
                return A;
            }
        }

        public int HeapSize
        {
            get
            {
                return HeapSize_;
            }
        }

        public Heap(int[] B)
        {
            A = B;
        }

        public void HeapSort()
        {
            BuildMaxHeap();

            for (var i = A.Length; i > 1; i--)
            {
                Swap(1, i);
                HeapSize_--;
                MaxHeapify(1);
            }
        }

        public void BuildMaxHeap()
        {
            HeapSize_ = A.Length;

            for (var i = A.Length / 2; i > 0; i--)
                MaxHeapify(i);
        }

        private void MaxHeapify(int i)
        {
            var max = i;
            var L = Left(i);
            var R = Right(i);

            if (L <= HeapSize_ && A[L - 1] > A[max - 1])
                max = L;            

            if (R <= HeapSize_ && A[R - 1] > A[max - 1])
                max = R;

            if (max != i) // non è un maxheap, allora swap e continua a scendere
            {
                Swap(i, max);
                MaxHeapify(max);
            } // è già maxheap esci
        }

        private void MaxHeapify2(int i)
        {
            var max = 0;
            var L = Left(i);
            var R = Right(i);

            if (L <= HeapSize_ && A[L - 1] > A[i - 1])
                max = L;
            else
                max = i;

            if (R <= HeapSize_ && A[R - 1] > A[max - 1])
                max = R;

            if (max != i)
            {
                Swap(i, max);
                MaxHeapify(max);
            }
        }

        private void Swap(int x, int y)
        {
            var temp = A[x - 1];
            A[x - 1] = A[y - 1];
            A[y - 1] = temp;
        }

        public int Parent(int i)
        {
            return i / 2;
        }

        public int Left(int i)
        {
            return 2 * i;
        }

        public int Right(int i)
        {
            return (2 * i) + 1;
        }


    }
}