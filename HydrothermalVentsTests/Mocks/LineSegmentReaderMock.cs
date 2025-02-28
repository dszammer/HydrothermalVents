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
    /// A mock implementation of the <see cref="ILineSegmentReader{T}"/> interface for testing purposes.
    /// </summary>
    /// <typeparam name="T">The type of the coordinates, which must be a value type.</typeparam>
    internal class LineSegmentReaderMock<T> : ILineSegmentReader<T> where T : struct
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LineSegmentReaderMock{T}"/> class with the specified line segments.
        /// </summary>
        /// <param name="lines">The list of line segments to read.</param>
        public LineSegmentReaderMock(List<LineSegment<T>>? lines)
        {
            m_linesegments = lines;
            m_index = 0;
        }

        /// <summary>
        /// Fetches the next line segment.
        /// </summary>
        /// <returns>A <see cref="LineSegment{T}"/> object representing the next line segment, or <c>null</c> if no more line segments are available.</returns>
        public LineSegment<T>? GetLineSegment()
        {
            if (m_linesegments != null && m_index < m_linesegments.Count)
            {
                return m_linesegments[m_index++];
            }

            return null;
        }

        private List<LineSegment<T>>? m_linesegments;
        private int m_index;
    }
}
