// (c)2022 David Szammer. All rights reserved.

using HydrothermalVents.BusinessLogic;

namespace HydrothermalVents.Parser
{
    public interface ILineSegmentParser<T> where T : struct
    {
        public LineSegment<T> FromString(string input);
        public string ToString(LineSegment<T> input);
    }
}
