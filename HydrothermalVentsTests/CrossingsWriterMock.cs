// (c)2022 David Szammer. All rights reserved.

using HydrothermalVents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HydrothermalVentsTests
{
    public class CrossingsWriterMock<U,T> : ICrossingsWriter<U,T> where U : struct where T : class
    {
        public void writeCrossings(ref List<Crossing<U, T>> crossings) { }
    }
}
