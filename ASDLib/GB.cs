/*
Copyright (C) 2019 [MAIONE MIKY]
This program is free software: you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation, either version 3 of the License, or (at your option) any later version. 
This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU General Public License for more details. 
You should have received a copy of the GNU General Public License along with this program. If not, see http://www.gnu.org/licenses/. 
*/
using System;

namespace ASDLib
{
    public static class GB
    {

        private static Random rnd = new Random(DateTime.Now.Second);


        public static T RndNumber<T>(T from__, T to__) where T : struct, IComparable<T>, IEquatable<T>
        {
            dynamic from_ = from__;
            dynamic to_ = to__;

            var r = rnd.NextDouble();
            var x = r * (to_ - from_) + from_;

            return (T)x;
        }


    }
}