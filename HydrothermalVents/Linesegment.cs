// (c)2022 David Szammer. All rights reserved.

using System;
using System.Collections.Generic;

namespace HydrothermalVents
{
    public class LineSegment<T> where T : struct
    {
        public LineSegment(T[] start, T[] end)
        {
            if (start.Length != end.Length)
                throw new LinesegmentException("Dimension missmatch.");

            m_start = start;
            m_end = end;
        }

        public T[] Start { get => m_start; set => m_start = value; }
        public T[] End { get => m_end; set => m_end = value; }

        private T[] m_start;
        private T[] m_end;
    }
}
