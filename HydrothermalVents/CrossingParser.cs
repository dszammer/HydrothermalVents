using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HydrothermalVents
{
    public class CrossingParser : ICrossingParser<int, LineSegment<int>>
    {
        public CrossingParser() { }
        public string ToString(Crossing<int, LineSegment<int>> crossing)
        {
            return $"({crossing.Position[0]},{crossing.Position[1]}) -> {crossing.Elements.Count}";
        }

        public Crossing<int, LineSegment<int>> FromString(string input)
        {
            throw new CrossingParserException("Not implemented");
        }
    }
}
