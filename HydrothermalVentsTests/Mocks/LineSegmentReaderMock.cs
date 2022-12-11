// (c)2022 David Szammer. All rights reserved.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HydrothermalVents.BusinessLogic;

namespace HydrothermalVentsTests
{
    internal class LineSegmentReaderMock<T> : ILineSegmentReader<T> where T : struct
    {
        public LineSegmentReaderMock(List<LineSegment<T>>? lines)
        {
            m_linesegments = lines;
            m_index = 0;
        }

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
