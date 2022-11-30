// (c)2022 David Szammer. All rights reserved.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HydrothermalVents
{
    public abstract class AbstractCrossingCalculator <U,T> where U : class where T: class
    {
        public abstract U? CalculateCrossing(T elementA, T elementB);
    }


    /// <summary>
    /// Class to calculate the crossing points of line segments.
    /// </summary>
    public class LineSegmentCrossingCalculator<U,T> where U : struct where T : struct// : AbstractCrossingCalculator<Crossing<int, LineSegment<int>>, LineSegment<int>>
    {
        /// <summary>
        /// Default CTOR
        /// </summary>
        public LineSegmentCrossingCalculator() 
        {
        }

        /// <summary>
        /// Calculates the crossing point of two line segments in 2 dimensional space
        /// by solving:
        /// Cx = ASx + (AEx - ASx)t = BSx + (BEx - BSx)t
        /// Cy = ASy + (AEy - ASy)u = BSy + (BEy - BSy)u
        /// https://en.wikipedia.org/wiki/Intersection_(geometry)#Two_line_segments
        /// param elementA: first of the two line segments.
        /// param elementB: second of the two line segments.
        /// return: If an intersection exist the point of intersection (containing both line segments).
        ///         null otherwise.
        /// </summary>
        public Crossing<T, LineSegment<U>>? CalculateCrossing(LineSegment<U> elementA, LineSegment<U> elementB)
        {
            int Ax = (int)(object)elementA.Start[0];
            int Ay = (int)(object)elementA.Start[1];

            int Bx = (int)(object)elementA.End[0];
            int By = (int)(object)elementA.End[1];

            int Cx = (int)(object)elementB.Start[0];
            int Cy = (int)(object)elementB.Start[1];

            int Dx = (int)(object)elementB.End[0];
            int Dy = (int)(object)elementB.End[1];

            int top = ((Dx - Cx) * (Ay - Cy)) - ((Dy - Cy) * (Ax - Cx));
            int bottom = ((Dy - Cy) * (Bx - Ax)) - ((Dx - Cx) * (By - Ay));

            if (bottom == 0)
            {
                // Lines are parallel so there is no crossing point.
                // The instructions are somewhat ambiguous about what happens
                // if two lines are overlaying each other.
                return null; 
            }

            if (((top * bottom) < 0) || (Math.Abs(top) > Math.Abs(bottom)))
            {
                //Intersection exist for lines. In case of line segments,
                //the intersection in outside of the line segments.
                return null;
            }

            int x = Ax + (((Bx - Ax) * top) / bottom);
            int y = Ay + (((By - Ay) * top) / bottom);

            return new Crossing<T, LineSegment<U>>(new T[] { (T)(object)x, (T)(object)y }, new List<LineSegment<U>>() { elementA, elementB });
        }
    }
}
