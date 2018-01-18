/*
Copyright (C) 2015 [MAIONE MIKY]
This program is free software: you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation, either version 3 of the License, or (at your option) any later version. 
This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU General Public License for more details. 
You should have received a copy of the GNU General Public License along with this program. If not, see http://www.gnu.org/licenses/. 
*/
namespace Grafi
{
    public class Nodo
    {

        public enum Color
        {
            Black,
            White,
            Gray
        }

        public Color color { get; set; }

        public Nodo Pred { get; set; }

        // BSF
        public int distance { get; set; }
        // BSF

        // DSF
        public int discovered { get; set; }

        public int finished { get; set; }
        // DSF

        public dynamic N { get; }

        // Tarjan
        public int minima_distanza { get; set; }

        public int indice { get; set; }
        // Tarjan

        public Nodo(dynamic n)
        {
            N = n;
            Sbianca();
        }

        public void Sbianca(int distanzaPredefinita = 0)
        {
            // BSF
            color = Color.White;
            distance = distanzaPredefinita;
            // BSF

            // DSF
            discovered = 0;
            finished = 0;
            // DSF

            //Tarjan
            indice = -1;
            minima_distanza = 0;
            //Tarjan
        }


    }
}