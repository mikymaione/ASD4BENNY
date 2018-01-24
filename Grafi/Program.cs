/*
Copyright (C) 2015 [MAIONE MIKY]
This program is free software: you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation, either version 3 of the License, or (at your option) any later version. 
This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU General Public License for more details. 
You should have received a copy of the GNU General Public License along with this program. If not, see http://www.gnu.org/licenses/. 
*/
using System.Collections.Generic;

namespace Grafi
{
    class Program
    {

        static void Main(string[] args)
        {
            System.Console.OutputEncoding = System.Text.Encoding.UTF8;

            //Main1(args);
            MainAlg_20160219(args);
        }

        static void MainAlg_20160219(string[] args)
        {
            var E_Completo = new dynamic[,]
            {
                { 1, 2 },
                { 2, 1 },
                { 1, 3 },
                { 3, 1 },
                { 2, 4 },
                { 4, 2 },
                { 3, 4 },
                { 4, 3 },
                { 2, 6 },
                { 6, 2 },
                { 5, 4 },
                { 4, 5 },
                { 5, 8 },
                { 8, 5 },
                { 7, 6 },
                { 6, 7 },
                { 10, 8 },
                { 8, 10 },
                { 10, 9 },
                { 9, 10 },
                { 7, 9 },
                { 9, 7 },
            };

            var A = new dynamic[] { 2, 4, 5, 6 };

            var G0 = new Esercizi("G0 E_Completo");
            G0.add_edges(E_Completo);
            G0.Alg_20160219(A, 3, 9);
        }

        static void Main2(string[] args)
        {
            var E_DAG5 = new dynamic[,]
            {
                { 1, 2 },
                { 2, 3 },
                { 3, 4 },
                { 4, 5 },
                { 1, 3 },
                { 3, 5 },
            };

            var E_with_3_cycles = new dynamic[,]
            {
                { 2, 1 },
                { 1, 3 },
                { 3, 4 },
                { 4, 5 },
                { 5, 4 },
                { 4, 6 },
                { 3, 2 },
                { 6, 6 },
            };

            var E_19_02_2016 = new dynamic[,]
            {
                { 1, 2 },
                { 1, 11 },
                { 2, 12 },
                { 3, 2 },
                { 3, 4 },
                { 4, 5 },
                { 6, 5 },
                { 6, 17 },
                { 7, 6 },
                { 7, 18 },
                { 8, 7 },
                { 8, 9 },
                { 10, 20 },
                { 12, 13 },
                { 12, 20 },
                { 13, 16 },
                { 14, 4 },
                { 15, 5 },
                { 16, 6 },
                { 17, 18 },
                { 18, 19 },
                { 19, 8 },
                { 19, 20 },
                { 20, 19 },
                { 2, 10 },
                { 2, 1 },
                { 11, 1 },
                { 2, 11 },
            };

            var E_with_1_cycles = new dynamic[,]
            {
                { 1, 2 },
                { 2, 3 },
                { 3, 1 },
                { 3, 7 },
                { 7, 8 },
                { 2, 5 },
                { 4, 5 },
                { 5, 6 },
                { 6, 4 },
            };

            var E_with_2_cycles = new dynamic[,]
            {
                { 6, 3 },
                { 1, 2 },
                { 2, 3 },
                { 3, 1 },
                { 3, 7 },
                { 7, 8 },
                { 2, 5 },
                { 4, 5 },
                { 5, 6 },
                { 6, 4 },
            };

            var E_DAG_Equals_E_with_2_cycles = new dynamic[,]
            {
                { 1, 2 },
                { 2, 3 },
                { 3, 7 },
                { 7, 8 },
                { 2, 5 },
                { 4, 5 },
                { 5, 6 },
            };

            var E_with_4_cycles = new dynamic[,]
            {
                { 1, 2 },
                { 3, 1 },
                { 2, 3 },
                { 4, 2 },
                { 4, 3 },
                { 6, 5 },
                { 6, 4 },
                { 4, 6 },
                { 5, 7 },
                { 7, 5 },
                { 8, 6 },
                { 8, 7 },
                { 5, 3 },
                { 8, 8 }
            };

            var E_DAG1 = new dynamic[,]
            {
                { 5, 11 },
                { 11, 2 },
                { 11, 10 },
                { 3, 10 },
                { 11, 9 },
                { 7, 11 },
                { 7, 8 },
                { 3, 8 },
                { 8, 9 },
                { 11, 1 }
            };

            var E_DAG2 = new dynamic[,]
            {
                { 1, 3 },
                { 2, 3 },
                { 3, 4 },
                { 4, 5 },
                { 4, 6 },
                { 5, 7 },
                { 5, 8 },
                { 6, 8 },
                { 6, 9 },
                { 7, 10 },
                { 8, 10 },
                { 9, 10 },
                { 3, 62 },
                { 62, 10 },
                { 4, 61 },
                { 61, 10 },
            };

            var E_with_8_cycles = new dynamic[,]
            {
                { 9, 101 },
                { 101, 101 },
                { 101, 102 },
                { 102, 102 },
                { 102, 2 },
                { 2, 4 },
                { 4, 5 },
                { 5, 12 },
                { 1, 5 },
                { 1, 2 },
                { 8, 40 },
                { 40, 8 },
                { 9, 8 },
                { 8, 1 },
                { 12, 20 },
                { 20, 90 },
                { 90, 12 },
                { 20, 50 },
                { 50, 70 },
                { 70, 14 },
                { 70, 12 },
                { 14, 50 },
                { 14, 23 },
                { 23, 71 },
                { 71, 23 },
                { 71, 3 },
                { 3, 17 },
                { 17, 3 },
                { 3, 9 },
            };

            var P = new Dictionary<int, string>();
            P.Add(1, "Primi");
            P.Add(3, "Primi");
            P.Add(5, "Primi");
            P.Add(2, "Due");

            var G0 = new Esercizi_20160623("G0 E_with_4_cycles", P);
            var G1 = new Esercizi_20160623("G1 E_DAG1", P);
            var G2 = new Esercizi_20160623("G2 E_DAG2", P);
            var G3 = new Esercizi_20160623("G3 E_with_1_cycles", P);
            var G4 = new Esercizi_20160623("G4 E_19_02_2016", P);
            var G5 = new Esercizi_20160623("G5 E_with_3_cycles", P);
            var G6 = new Esercizi_20160623("G6 E_with_8_cycles", P);
            var G7 = new Esercizi_20160623("G7 E_with_2_cycles", P);
            var G8 = new Esercizi_20160623("G8 E_DAG_Equals_E_with_2_cycles", P);
            var G9 = new Esercizi_20160623("G9 E_DAG5", P);

            G0.add_edges(E_with_4_cycles);
            G1.add_edges(E_DAG1);
            G2.add_edges(E_DAG2);
            G3.add_edges(E_with_1_cycles);
            G4.add_edges(E_19_02_2016);
            G5.add_edges(E_with_3_cycles);
            G6.add_edges(E_with_8_cycles);
            G7.add_edges(E_with_2_cycles);
            G8.add_edges(E_DAG_Equals_E_with_2_cycles);
            G9.add_edges(E_DAG5);

            G0.Algo_20160623(7, "Primi");
            G1.Algo_20160623(5, "Primi");
            G2.Algo_20160623(4, "Primi");
            G3.Algo_20160623(4, "Primi");
            G4.Algo_20160623(4, "Primi");
            G5.Algo_20160623(4, "Primi");
            G6.Algo_20160623(4, "Primi");
            G7.Algo_20160623(4, "Primi");
            G8.Algo_20160623(4, "Primi");
            G9.Algo_20160623(4, "Primi");
        }

        static void Main1(string[] args)
        {
            var E_Ragno = new dynamic[,]
            {
                { 1, 2 },
                { 1, 3 },
                { 1, 4 },
                { 1, 5 },
                { 1, 5 },
                { 2, 8 },
                { 3, 8 },
                { 4, 8 },
                { 5, 8 },
                { 6, 8 },
                { 2, 7 },
                { 3, 7 },
                { 4, 7 },
                { 5, 7 },
                { 6, 7 },
                { 2, 9 },
                { 3, 9 },
                { 4, 9 },
                { 5, 9 },
                { 6, 9 },
                { 8, 7 },
                { 7, 8 },
                { 7, 9 },
                { 9, 7 },
            };

            var E_9 = new dynamic[,]
            {
                { 1, 2 },
                { 2, 3 },
                { 3, 4 },
                { 4, 5 },
                { 5, 5 },
                { 1, 6 },
                { 6, 7 },
                { 7, 8 },
                { 8, 9 },
            };

            var E_10 = new dynamic[,]
            {
                { 5, 5 },
                { 1, 2 },
                { 2, 3 },
                { 3, 4 },
                { 4, 5 },
                { 5, 5 },
                { 1, 6 },
                { 6, 7 },
                { 7, 8 },
                { 8, 9 },
                { 9, 5 },
            };

            var E_Pag516 = new dynamic[,]
            {
                { "a", "b" },
                { "b", "c" },
                { "b", "f" },
                { "b", "e" },
                { "c", "d" },
                { "c", "g" },
                { "d", "c" },
                { "d", "h" },
                { "h", "h" },
                { "g", "f" },
                { "g", "h" },
                { "f", "g" },
                { "e", "f" },
                { "e", "a" },
            };

            var E_Stella3 = new dynamic[,]
            {
                { 1, 2 },
                { 1, 5 },
                { 1, 4 },
                { 1, 6 },
                { 1, 3 },
                { 5, 2 },
                { 5, 6 },
                { 2, 3 },
                { 2, 5 },
                { 6, 4 },
                { 6, 5 },
                { 6, 3 },
                { 3, 4 },
                { 3, 6 },
                { 3, 2 },
                { 4, 6 },
                { 4, 3 },
                { 4, 7 },
                { 7, 8 },
                { 8, 7 },
            };

            var E_Stella5 = new dynamic[,]
            {
                { 1, 2 },
                { 1, 5 },
                { 1, 4 },
                { 1, 6 },
                { 1, 3 },
                { 5, 2 },
                { 5, 6 },
                { 2, 3 },
                { 2, 5 },
                { 6, 4 },
                { 6, 5 },
                { 6, 3 },
                { 3, 4 },
                { 3, 6 },
                { 3, 2 },
                { 4, 6 },
                { 4, 3 },
                { 4, 7 },
                { 7, 8 },
                { 8, 1 },
            };

            var E_Stella4 = new dynamic[,]
            {
                { 1, 2 },
                { 1, 5 },
                { 1, 4 },
                { 1, 6 },
                { 1, 3 },
                { 5, 2 },
                { 5, 6 },
                { 2, 3 },
                { 2, 5 },
                { 6, 4 },
                { 6, 5 },
                { 6, 3 },
                { 3, 4 },
                { 3, 6 },
                { 3, 2 },
                { 4, 6 },
                { 4, 3 },
                { 4, 7 },
                { 7, 4 },
            };

            var E_Stella2 = new dynamic[,]
            {
                { 1, 2 },
                { 1, 5 },
                { 1, 4 },
                { 1, 6 },
                { 1, 3 },
                { 5, 2 },
                { 5, 6 },
                { 2, 3 },
                { 2, 5 },
                { 6, 4 },
                { 6, 5 },
                { 6, 3 },
                { 3, 4 },
                { 3, 6 },
                { 3, 2 },
                { 4, 6 },
                { 4, 3 },
                { 4, 7 },
                { 7, 1 },
            };

            var E_DAG5 = new dynamic[,]
            {
                { 1, 2 },
                { 2, 3 },
                { 3, 4 },
                { 4, 5 },
                { 1, 3 },
                { 3, 5 },
            };

            var E_with_3_cycles = new dynamic[,]
            {
                { 2, 1 },
                { 1, 3 },
                { 3, 4 },
                { 4, 5 },
                { 5, 4 },
                { 4, 6 },
                { 3, 2 },
                { 6, 6 },
            };

            var E_without_3_cycles = new dynamic[,]
            {
                { 2, 1 },
                { 1, 3 },
                { 3, 4 },
                { 4, 5 },
                { 5, 6 },
                { 4, 6 },
                { 3, 2 },
            };

            var E_19_02_2016 = new dynamic[,]
            {
                { 1, 2 },
                { 1, 11 },
                { 2, 12 },
                { 3, 2 },
                { 3, 4 },
                { 4, 5 },
                { 6, 5 },
                { 6, 17 },
                { 7, 6 },
                { 7, 18 },
                { 8, 7 },
                { 8, 9 },
                { 10, 20 },
                { 12, 13 },
                { 12, 20 },
                { 13, 16 },
                { 14, 4 },
                { 15, 5 },
                { 16, 6 },
                { 17, 18 },
                { 18, 19 },
                { 19, 8 },
                { 19, 20 },
                { 20, 19 },
                { 2, 10 },
                { 2, 1 },
                { 11, 1 },
                { 2, 11 },
            };

            var E_with_1_cycles = new dynamic[,]
            {
                { 1, 2 },
                { 2, 3 },
                { 3, 1 },
                { 3, 7 },
                { 7, 8 },
                { 2, 5 },
                { 4, 5 },
                { 5, 6 },
                { 6, 4 },
            };

            var E_with_2_cycles = new dynamic[,]
            {
                { 6, 3 },
                { 1, 2 },
                { 2, 3 },
                { 3, 1 },
                { 3, 7 },
                { 7, 8 },
                { 2, 5 },
                { 4, 5 },
                { 5, 6 },
                { 6, 4 },
            };

            var E_DAG_Equals_E_with_2_cycles = new dynamic[,]
            {
                { 1, 2 },
                { 2, 3 },
                { 3, 7 },
                { 7, 8 },
                { 2, 5 },
                { 4, 5 },
                { 5, 6 },
            };

            var E_with_4_cycles = new dynamic[,]
            {
                { 1, 2 },
                { 3, 1 },
                { 2, 3 },
                { 4, 2 },
                { 4, 3 },
                { 6, 5 },
                { 6, 4 },
                { 4, 6 },
                { 5, 7 },
                { 7, 5 },
                { 8, 6 },
                { 8, 7 },
                { 5, 3 },
                { 8, 8 }
            };

            var E_DAG1 = new dynamic[,]
            {
                { 5, 11 },
                { 11, 2 },
                { 11, 10 },
                { 3, 10 },
                { 11, 9 },
                { 7, 11 },
                { 7, 8 },
                { 3, 8 },
                { 8, 9 },
                { 11, 1 }
            };

            var E_DAG2 = new dynamic[,]
            {
                { 1, 3 },
                { 2, 3 },
                { 3, 4 },
                { 4, 5 },
                { 4, 6 },
                { 5, 7 },
                { 5, 8 },
                { 6, 8 },
                { 6, 9 },
                { 7, 10 },
                { 8, 10 },
                { 9, 10 },
                { 3, 62 },
                { 62, 10 },
                { 4, 61 },
                { 61, 10 },
            };

            var E_with_8_cycles = new dynamic[,]
            {
                { 9, 101 },
                { 101, 101 },
                { 101, 102 },
                { 102, 102 },
                { 102, 2 },
                { 2, 4 },
                { 4, 5 },
                { 5, 12 },
                { 1, 5 },
                { 1, 2 },
                { 8, 40 },
                { 40, 8 },
                { 9, 8 },
                { 8, 1 },
                { 12, 20 },
                { 20, 90 },
                { 90, 12 },
                { 20, 50 },
                { 50, 70 },
                { 70, 14 },
                { 70, 12 },
                { 14, 50 },
                { 14, 23 },
                { 23, 71 },
                { 71, 23 },
                { 71, 3 },
                { 3, 17 },
                { 17, 3 },
                { 3, 9 },
            };

            var G0 = new Esercizi("G0 E_with_4_cycles");
            var G1 = new Esercizi("G1 E_DAG1");
            var G2 = new Esercizi("G2 E_DAG2");
            var G3 = new Esercizi("G3 E_with_1_cycles");
            var G4 = new Esercizi("G4 E_19_02_2016");
            var G5 = new Esercizi("G5 E_with_3_cycles");
            var G5b = new Esercizi("G5b E_without_3_cycles");
            var G6 = new Esercizi("G6 E_with_8_cycles");
            var G7 = new Esercizi("G7 E_with_2_cycles");
            var G8 = new Esercizi("G8 E_DAG_Equals_E_with_2_cycles");
            var G9 = new Esercizi("G9 E_DAG5");
            var G10 = new Esercizi("G10 E_Stella4");
            var G11 = new Esercizi("G11 E_Stella2");
            var G12 = new Esercizi("G12 E_Stella5");
            var G13 = new Esercizi("G13 E_Stella3");
            var G14 = new Esercizi("G14 E_Pag516");
            var G15 = new Esercizi("G15 E_9");
            var G16 = new Esercizi("G16 E_10");
            var G17 = new Esercizi("G17 E_Ragno");

            G0.add_edges(E_with_4_cycles);
            G1.add_edges(E_DAG1);
            G2.add_edges(E_DAG2);
            G3.add_edges(E_with_1_cycles);
            G4.add_edges(E_19_02_2016);
            G5.add_edges(E_with_3_cycles);
            G5b.add_edges(E_without_3_cycles);
            G6.add_edges(E_with_8_cycles);
            G7.add_edges(E_with_2_cycles);
            G8.add_edges(E_DAG_Equals_E_with_2_cycles);
            G9.add_edges(E_DAG5);
            G10.add_edges(E_Stella4);
            G11.add_edges(E_Stella2);
            G12.add_edges(E_Stella5);
            G13.add_edges(E_Stella3);
            G14.add_edges(E_Pag516);
            G15.add_edges(E_9);
            G16.add_edges(E_10);
            G17.add_edges(E_Ragno);

            /*
            var A = new int[] { 1, 3 };
            var B = new int[] { 1, 2, 3 };
            var C = new int[] { 3, 5, 9, 12, 23, 50 };
            var D = new int[] { 4, 3, 6 };
            var E = new int[] { 6 };
            var F = new int[] { 6, 5, 3, 2, 1, 7 };
            var G = new int[] { 5, 6, 4 };
            */

            /*
            G0.Algo_20170224(B);
            G1.Algo_20170224(B);
            G2.Algo_20170224(B);
            G3.Algo_20170224(B);
            G3.Algo_20170224(D);
            G3.Algo_20170224(G);
            G4.Algo_20170224(B);
            G5.Algo_20170224(B);
            G6.Algo_20170224(C);
            G7.Algo_20170224(A);
            G7.Algo_20170224(D);
            G7.Algo_20170224(E);
            G7.Algo_20170224(F);
            G8.Algo_20170224(A);
            G8.Algo_20170224(B);
            G8.Algo_20170224(D);
            G8.Algo_20170224(E);
            G8.Algo_20170224(F);
            */

            G0.Algo_20170126_1();
            /*
            G1.Algo_20170126_1();
            G2.Algo_20170126_1();
            G3.Algo_20170126_1();
            G4.Algo_20170126_1();
            G5.Algo_20170126_1();
            G5b.Algo_20170126_1();
            G6.Algo_20170126_1();
            G7.Algo_20170126_1();
            G8.Algo_20170126_1();
            G9.Algo_20170126_1();
            G10.Algo_20170126_1();
            G11.Algo_20170126_1();
            G12.Algo_20170126_1();
            G13.Algo_20170126_1();
            G14.Algo_20170126_1();
            G15.Algo_20170126_1();
            G16.Algo_20170126_1();
            G17.Algo_20170126_1();
            */
            /*
            G0.Algo_20170126_2();
            G1.Algo_20170126_2();
            G2.Algo_20170126_2();
            G3.Algo_20170126_2();
            G4.Algo_20170126_2();
            G5.Algo_20170126_2();
            G6.Algo_20170126_2();
            G7.Algo_20170126_2();
            G8.Algo_20170126_2();
            */

            /*
            G0.Algo_20160909(1, 8, 2, 6);
            G1.Algo_20160909(1, 8, 2, 6);
            G2.Algo_20160909(1, 8, 2, 6);
            G3.Algo_20160909(1, 8, 2, 6);
            G4.Algo_20160909(1, 8, 2, 6);
            G5.Algo_20160909(1, 6, 2, 3);
            G6.Algo_20160909(1, 17, 2, 5);
            G7.Algo_20160909(1, 8, 2, 6);
            G8.Algo_20160909(1, 8, 2, 6);
            */

            //G1.Topological_Sorting();
            //G2.Topological_Sorting();

            /*
            G0.VediInFinestra();
            G1.VediInFinestra();
            G2.VediInFinestra();
            G3.VediInFinestra();
            G4.VediInFinestra();
            G5.VediInFinestra();
            G5b.VediInFinestra();
            G6.VediInFinestra();
            G7.VediInFinestra();
            G8.VediInFinestra();
            G9.VediInFinestra();
            G10.VediInFinestra();
            */

            /*
            var k = 8;
            G0.Algo_20160623(1, 3, 5, k);
            G1.Algo_20160623(1, 3, 5, k);
            G2.Algo_20160623(1, 3, 5, k);
            G3.Algo_20160623(1, 3, 5, k);
            G4.Algo_20160623(1, 3, 5, k);
            G5.Algo_20160623(1, 3, 5, k);
            G6.Algo_20160623(1, 3, 5, k);
            G7.Algo_20160623(1, 3, 5, k);
            G8.Algo_20160623(1, 3, 5, k);
            G9.Algo_20160623(1, 3, 5, k);
            */

            /*
            G0.Alg_20160219(D, 1, 8);
            G1.Alg_20160219(D, 1, 8);
            G2.Alg_20160219(D, 1, 8);
            G3.Alg_20160219(D, 1, 8);
            G4.Alg_20160219(D, 1, 8);
            G5.Alg_20160219(D, 1, 8);
            G6.Alg_20160219(D, 1, 8);
            G7.Alg_20160219(D, 1, 8);
            G8.Alg_20160219(D, 1, 8);
            */

            /*
            G0.Algo_20160128(A);
            G1.Algo_20160128(A);
            G2.Algo_20160128(A);
            G3.Algo_20160128(A);
            G4.Algo_20160128(A);
            G5.Algo_20160128(A);
            G6.Algo_20160128(A);
            G7.Algo_20160128(new int[] { 6, 3, 1, 5 });
            //G7.Algo_20160128_Cerqua(new int[] { 3, 1, 2 });
            //G7.Algo_20160128_Cerqua(new int[] { 6, 3, 4, 5 });
            G8.Algo_20160128(A);
            G9.Algo_20160128(A);            
            */

            /*
            G0.Alg_20170628_1(8, 7, 5, 3); //true
            G1.Alg_20170628_1(1, 2, 3, 7); //false
            G2.Alg_20170628_1(1, 3, 4, 6); //false
            G3.Alg_20170628_1(1, 2, 3, 7); //false
            G3.Alg_20170628_1(1, 2, 5, 6); //true
            G4.Alg_20170628_1(1, 2, 10, 8); //false
            G5.Alg_20170628_1(2, 1, 3, 4); //true
            G5b.Alg_20170628_1(2, 1, 3, 4); //false
            G6.Alg_20170628_1(1, 4, 12, 3); //true?
            G7.Alg_20170628_1(6, 1, 2, 5); //true
            G8.Alg_20170628_1(1, 2, 3, 7); //false
            G9.Alg_20170628_1(1, 2, 3, 4); //false
            G10.Alg_20170628_1(1, 2, 3, 4); //true
            G11.Alg_20170628_1(1, 2, 3, 4); //true
            G12.Alg_20170628_1(1, 2, 3, 4); //true
            G13.Alg_20170628_1(1, 2, 3, 4); //true
            */

            /*
            G0.Alg_20170628_2(8, 7, 3); //true
            G1.Alg_20170628_2(1, 2, 7); //false
            G2.Alg_20170628_2(1, 3, 6); //false
            G3.Alg_20170628_2(1, 2, 7); //false
            G3.Alg_20170628_2(1, 2, 6); //true
            G4.Alg_20170628_2(1, 2, 8); //false
            G5.Alg_20170628_2(2, 1, 4); //true
            G5b.Alg_20170628_2(2, 1, 4); //false
            G6.Alg_20170628_2(1, 4, 3); //true?
            G7.Alg_20170628_2(6, 1, 5); //true
            G8.Alg_20170628_2(1, 2, 7); //false
            G9.Alg_20170628_2(1, 2, 4); //false
            G10.Alg_20170628_2(1, 2, 4); //true
            G11.Alg_20170628_2(1, 2, 4); //true
            G12.Alg_20170628_2(1, 2, 4); //true
            G13.Alg_20170628_2(1, 2, 4); //true
            */

            /*
            G0.Alg_20171016(new dynamic[] { 1, 6, 5, 7 });
            G1.Alg_20171016(new dynamic[] { 11, 8 });
            G2.Alg_20171016(new dynamic[] { 4, 6, 5, 61, 62 });            
            G3.Alg_20171016(B);
            G4.Alg_20171016(B);
            G5.Alg_20171016(B);
            G5b.Alg_20171016(B);
            G6.Alg_20171016(B);
            G7.Alg_20171016(B);
            G8.Alg_20171016(B);
            G9.Alg_20171016(B);
            G10.Alg_20171016(B);
            G11.Alg_20171016(B);
            G12.Alg_20171016(B);
            G13.Alg_20171016(B);
            G15.Alg_20171016(B);
            G16.Alg_20171016(B);
            G17.Alg_20171016(B);
            */
            /*
            G0.Alg_20170718_1(3);
            G1.Alg_20170718_1(3);
            G2.Alg_20170718_1(3);
            G3.Alg_20170718_1(4);
            G4.Alg_20170718_1(3);
            G5.Alg_20170718_1(3);
            G5b.Alg_20170718_1(3);
            G6.Alg_20170718_1(3);
            G7.Alg_20170718_1(6);
            G8.Alg_20170718_1(3);
            G9.Alg_20170718_1(3);
            G10.Alg_20170718_1(3);
            G11.Alg_20170718_1(3);
            G12.Alg_20170718_1(3);
            G13.Alg_20170718_1(3);
            G14.Alg_20170718_1(3);
            G15.Alg_20170718_1(3);
            G16.Alg_20170718_1(3);
            G17.Alg_20170718_1(3);
            */

            /*
            G0.Alg_20170718_2(8, 1, 4);
            G0.Alg_20170718_2(8, 1, 5);
            G1.Alg_20170718_2(1, 2, 3);
            G2.Alg_20170718_2(1, 2, 3);
            G3.Alg_20170718_2(1, 2, 3);
            G4.Alg_20170718_2(1, 2, 3);
            G5.Alg_20170718_2(1, 2, 3);
            G5b.Alg_20170718_2(1, 2, 3);
            G6.Alg_20170718_2(1, 2, 3);
            G7.Alg_20170718_2(1, 2, 3);
            G8.Alg_20170718_2(1, 2, 3);
            G9.Alg_20170718_2(1, 2, 3);
            G10.Alg_20170718_2(1, 2, 3);
            G11.Alg_20170718_2(1, 2, 3);
            G12.Alg_20170718_2(1, 2, 3);
            G13.Alg_20170718_2(1, 2, 3);
            G14.Alg_20170718_2("a", "b", "c");
            G15.Alg_20170718_2(1, 5, 3);
            G16.Alg_20170718_2(1, 5, 3);
            G17.Alg_20170718_2(1, 7, 9);
            */
        }


    }
}