// (c)2022 David Szammer. All rights reserved.

using HydrothermalVents.Exceptions;

namespace HydrothermalVents.BusinessLogic
{
    /// <summary>
    /// Generic line segment class.
    /// A line segment is defined by its start and end point in n-dimensional space.
    /// </summary>
    public class LineSegment<T> where T : struct
    {
        /// <summary>
        /// CTOR 
        /// param start: Point in n dimensions.
        /// param end: Point in n dimensions.
        /// Notice: Dimensions have to be the same for both points.
        /// </summary>
        public LineSegment(T[] start, T[] end)
        {
            if (start.Length != end.Length)
                throw new LineSegmentException("Dimension missmatch.");

            m_start = start;
            m_end = end;
        }

        public T[] Start { get => m_start; }
        public T[] End { get => m_end; }

        private T[] m_start;
        private T[] m_end;
    }
}
