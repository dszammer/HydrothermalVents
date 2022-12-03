using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HydrothermalVents
{
    public interface ICrossingParser<T,U> where T : struct where U : class
    {
        public Crossing<int, LineSegment<int>> FromString(string input);
        public string ToString(Crossing<int, LineSegment<int>> crossing);
    }
}
