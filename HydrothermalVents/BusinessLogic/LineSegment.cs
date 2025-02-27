// (c)2022 David Szammer. All rights reserved.

using HydrothermalVents.Exceptions;

namespace HydrothermalVents.BusinessLogic
{
    /// <summary>
    /// Represents a generic line segment defined by its start and end points in n-dimensional space.
    /// </summary>
    /// <typeparam name="T">The type of the coordinates, which must be a value type.</typeparam>
    public class LineSegment<T> where T : struct
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LineSegment{T}"/> class with specified start and end points.
        /// </summary>
        /// <param name="start">The start point of the line segment in n dimensions.</param>
        /// <param name="end">The end point of the line segment in n dimensions.</param>
        /// <exception cref="LineSegmentException">Thrown when the dimensions of the start and end points do not match.</exception>
        /// <remarks>
        /// The dimensions of the start and end points must be the same.
        /// </remarks>
        public LineSegment(T[] start, T[] end)
        {
            if (start.Length != end.Length)
                throw new LineSegmentException("Dimension missmatch.");

            m_start = start;
            m_end = end;
        }

        /// <summary>
        /// Gets the start point of the line segment.
        /// </summary>
        /// <value>
        /// An array of type <see cref="T"/> representing the start point in n dimensions.
        /// </value>
        public T[] Start { get => m_start; }

        /// <summary>
        /// Gets the end point of the line segment.
        /// </summary>
        /// <value>
        /// An array of type <see cref="T"/> representing the end point in n dimensions.
        /// </value>
        public T[] End { get => m_end; }

        private T[] m_start;
        private T[] m_end;
    }
}
