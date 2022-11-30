// (c)2022 David Szammer. All rights reserved.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HydrothermalVents
{
    public interface ICrossingsWriter<U, T> where U : struct
                                            where T : class
    {
        public void writeCrossings(List<Crossing<U,T>> crossings);
    }
}
