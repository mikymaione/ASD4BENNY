/*
Copyright (C) 2015 [MAIONE MIKY]
This program is free software: you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation, either version 3 of the License, or (at your option) any later version. 
This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU General Public License for more details. 
You should have received a copy of the GNU General Public License along with this program. If not, see http://www.gnu.org/licenses/. 
*/
using System;
using System.Collections.Generic;

namespace Vector
{
    public sealed class Vector<T>  where T : class
    {
        
        private long lunghezza;
        private long indice = -1;

        private T[] A;

        public Vector(long lunghezza_)
        {
            lunghezza = lunghezza_;
            A = new T[lunghezza_];
        }

        public T getAt(long x)
        {
            return A[x];
        }

        public long Indice
        {
            get
            {
                return indice;
            }
        }

        public T First()
        {
            return A[0];
        }

        public T Back()
        {
            if (indice > -1)
                return A[indice];
            else
                return null;
        }

        public bool Contains(T e)
        {
            for (var i = 0; i <= indice; i++)
                if (A[i] == e)
                    return true;                

            return false;
        }

        public void Add(T e)
        {
            indice++;
            A[indice] = e;
        }

        public void Delete(long x)
        {
            for (var i = x; i <= indice; i++)
                A[i] = A[i + 1];       

            indice--;
        }


    }
}