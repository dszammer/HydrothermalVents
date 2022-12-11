// (c)2022 David Szammer. All rights reserved.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HydrothermalVents.BusinessLogic
{
    public interface ILineSegmentReader<T> where T : struct
    {
        public LineSegment<T>? GetLineSegment();
    }
}
