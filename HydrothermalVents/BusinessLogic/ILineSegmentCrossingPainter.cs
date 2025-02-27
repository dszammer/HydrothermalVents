using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HydrothermalVents.BusinessLogic
{
    /// <summary>
    /// Interface for painting or visualizing line segments and their crossings.
    /// </summary>
    /// <typeparam name="U">The type of the coordinates, which must be a value type.</typeparam>
    /// <typeparam name="T">The type of the line segments, which must be a reference type.</typeparam>
    public interface ILineSegmentCrossingPainter<U, T> where U : struct where T : class
    {
        /// <summary>
        /// Draws the provided line segments and their crossings.
        /// </summary>
        /// <param name="lineSegments">The list of line segments to be drawn.</param>
        /// <param name="crossings">The list of crossings to be drawn.</param>
        public void draw(List<T> lineSegments, List<Crossing<U, T>> crossing);
    }
}
