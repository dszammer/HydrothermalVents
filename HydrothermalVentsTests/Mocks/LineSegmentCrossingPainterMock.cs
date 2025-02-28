// (c)2022 David Szammer. All rights reserved.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HydrothermalVents.BusinessLogic;

namespace HydrothermalVentsTests
{
    /// <summary>
    /// A mock implementation of the <see cref="ILineSegmentCrossingPainter{T, U}"/> interface for testing purposes.
    /// </summary>
    public class LineSegmentCrossingPainterMock : ILineSegmentCrossingPainter<int, LineSegment<int>>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LineSegmentCrossingPainterMock"/> class.
        /// </summary>
        public LineSegmentCrossingPainterMock() { }

        /// <summary>
        /// Simulates the drawing of crossings
        /// </summary>
        /// <param name="lineSegments">The list of line segments to draw.</param>
        /// <param name="crossing">The list of crossings to draw.</param>
        public void draw(List<LineSegment<int>> lineSegments, List<Crossing<int, LineSegment<int>>> crossing) { m_drew = true; }

        public bool m_drew = false;
    }
}
