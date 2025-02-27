// (c)2022 David Szammer. All rights reserved.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HydrothermalVents.BusinessLogic
{
    /// <summary>
    /// Class to calculate the crossing points of line segments.
    /// This is where the magic happens!
    /// </summary>
    /// <remarks>
    /// The <see cref="LineSegmentCrossingCalculator"/> class implements the <see cref="ICrossingCalculator{int, LineSegment{int}}"/> interface
    /// to calculate the intersection points of line segments in 2-dimensional space.
    /// </remarks>
    public class LineSegmentCrossingCalculator : ICrossingCalculator<int, LineSegment<int>>
    {
        /// <summary>
        /// Calculates the crossing point of two line segments in 2-dimensional space
        /// by solving:
        /// Cx = ASx + (AEx - ASx)t = BSx + (BEx - BSx)t
        /// Cy = ASy + (AEy - ASy)u = BSy + (BEy - BSy)u
        /// </summary>
        /// <param name="elementA">The first line segment.</param>
        /// <param name="elementB">The second line segment.</param>
        /// <returns>
        /// A <see cref="Crossing{int, LineSegment{int}}"/> object representing the point of intersection (containing both line segments),
        /// or <c>null</c> if no intersection exists.
        /// </returns>
        /// <remarks>
        /// The method uses the parametric equations of the line segments to determine the intersection point.
        /// If the line segments are parallel or do not intersect within their lengths, the method returns <c>null</c>.
        /// For more information, see <a href="https://en.wikipedia.org/wiki/Intersection_(geometry)#Two_line_segments">Intersection of two line segments</a>.
        /// </remarks>
        public Crossing<int, LineSegment<int>>? CalculateCrossing(LineSegment<int> elementA, LineSegment<int> elementB)
        {
            int Ax = elementA.Start[0];
            int Ay = elementA.Start[1];

            int Bx = elementA.End[0];
            int By = elementA.End[1];

            int Cx = elementB.Start[0];
            int Cy = elementB.Start[1];

            int Dx = elementB.End[0];
            int Dy = elementB.End[1];

            int ttop = (Dx - Cx) * (Ay - Cy) - (Dy - Cy) * (Ax - Cx);
            int utop = (Cy - Ay) * (Ax - Bx) - (Cx - Ax) * (Ay - By);
            int bottom = (Dy - Cy) * (Bx - Ax) - (Dx - Cx) * (By - Ay);

            if (bottom == 0)
            {
                // Lines are parallel so there is no crossing point.
                // The instructions are somewhat ambiguous about what happens
                // if two lines are overlaying each other.
                return null;
            }

            if (ttop * bottom < 0
                || utop * bottom < 0
                || Math.Abs(ttop) > Math.Abs(bottom)
                || Math.Abs(utop) > Math.Abs(bottom))
            {
                //Intersection exist for lines. In case of line segments,
                //the intersection in outside of the line segments.
                return null;
            }

            int x = Ax + (Bx - Ax) * ttop / bottom;
            int y = Ay + (By - Ay) * ttop / bottom;

            return new Crossing<int, LineSegment<int>>(new int[] { x, y }, new List<LineSegment<int>>() { elementA, elementB });
        }

        /// <summary>
        /// Checks if a line segment satisfies certain constraints.
        /// </summary>
        /// <param name="elementA">The line segment to check.</param>
        /// <returns>
        /// <c>true</c> if the line segment is horizontal, vertical, or diagonal (45°); otherwise, <c>false</c>.
        /// </returns>
        /// <remarks>
        /// This method ensures that the line segment meets specific criteria before calculating intersections.
        /// </remarks>
        public bool LineSegmentSatisfiesConstraints(LineSegment<int> elementA)
        {
            return elementA.Start[0] == elementA.End[0]
                || elementA.Start[1] == elementA.End[1]
                || Math.Abs(elementA.Start[0] - elementA.End[0]) == Math.Abs(elementA.Start[1] - elementA.End[1]);
        }
    }
}
