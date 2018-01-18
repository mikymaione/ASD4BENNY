/*
Copyright (C) 2015 [MAIONE MIKY]
This program is free software: you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation, either version 3 of the License, or (at your option) any later version. 
This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU General Public License for more details. 
You should have received a copy of the GNU General Public License along with this program. If not, see http://www.gnu.org/licenses/. 
*/
using System;

namespace Complessita
{
    class Program
    {
        static void Main(string[] args)
        {
            double n = 12345;

            var C = A20170224(n);
            Console.WriteLine($"Complessità {C} su {n}");
            Console.WriteLine($"Complessità n*n {C} su {n * n}");
            Console.WriteLine($"Complessità n*n*n {C} su {n * n * n}");
            Console.WriteLine($"Complessità logn {C} su {Math.Log(n, 2)}");
            Console.WriteLine($"Complessità n*logn {C} su {n * Math.Log(n, 2)}");
        }

        static int A20170224(double n)
        {
            var H = 0;
            var K = 0;

            double x = 0;
            double z = n;
            var C = 2;

            while (x < (n * n))
            {
                K++;
                double j = 1;

                while (z > Math.Log(j, 2))
                {                    
                    H++;
                    j = j * 2;
                    z = z - 2;
                    C = C + 3;

                    Console.WriteLine($"H{H}# j:{j} z:{z} Log {Math.Log(j, 2)}");
                }

                x = x + (3 * z);
                C = C + 3;

                Console.WriteLine($"K{K}# j:{j} z:{z} x:{x}");
            }

            return C;
        }


    }
}