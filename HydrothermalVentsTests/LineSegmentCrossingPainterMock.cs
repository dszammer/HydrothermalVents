using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HydrothermalVents;

namespace HydrothermalVentsTests
{
    public class LineSegmentCrossingPainterMock : ILineSegmentCrossingPainter<int, LineSegment<int>> 
    {
        public LineSegmentCrossingPainterMock() { }
        public void draw(List<LineSegment<int>> lineSegments, List<Crossing<int, LineSegment<int>>> crossing) { }
    }
}
