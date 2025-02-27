// (c)2022 David Szammer. All rights reserved.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HydrothermalVents.BusinessLogic
{
    /// <summary>
    /// Interface for reading line segments.
    /// </summary>
    /// <typeparam name="T">The type of the coordinates, which must be a value type.</typeparam>
    public interface ILineSegmentReader<T> where T : struct
    {
        /// <summary>
        /// Fetches the next line segment.
        /// </summary>
        /// <returns>A <see cref="LineSegment{T}"/> object representing the next line segment, or <c>null</c> if no more line segments are available.</returns>
        public LineSegment<T>? GetLineSegment();
    }
}
