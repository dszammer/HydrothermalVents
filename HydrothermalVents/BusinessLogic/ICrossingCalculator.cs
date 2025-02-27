// (c)2022 David Szammer. All rights reserved.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HydrothermalVents.BusinessLogic
{
    /// <summary>
    /// Interface for calculating crossings between elements and checking constraints on line segments.
    /// </summary>
    /// <typeparam name="U">The type of the coordinates, which must be a value type.</typeparam>
    /// <typeparam name="T">The type of the elements, which must be a reference type.</typeparam>
    public interface ICrossingCalculator<U, T> where U : struct where T : class
    {
        /// <summary>
        /// Calculates the crossing point between two elements.
        /// </summary>
        /// <param name="elementA">The first element.</param>
        /// <param name="elementB">The second element.</param>
        /// <returns>A <see cref="Crossing{U, T}"/> object representing the crossing point, or <c>null</c> if no crossing is found.</returns>
        public Crossing<U, T>? CalculateCrossing(T elementA, T elementB);

        /// <summary>
        /// Checks if a line segment satisfies certain constraints of the implemented crossing point calculation.
        /// </summary>
        /// <param name="elementA">The line segment to check.</param>
        /// <returns><c>true</c> if the line segment satisfies the constraints; otherwise, <c>false</c>.</returns>
        public bool LineSegmentSatisfiesConstraints(T elementA);
    }

}
