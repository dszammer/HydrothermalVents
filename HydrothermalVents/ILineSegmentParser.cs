using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HydrothermalVents
{
    public interface ILineSegmentParser<T> where T : struct
    {
        public LineSegment<T> FromString(string input);
        public string ToString(LineSegment<T> input);
    }
}
