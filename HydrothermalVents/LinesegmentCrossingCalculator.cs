// (c)2022 David Szammer. All rights reserved.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HydrothermalVents
{
    /// <summary>
    /// Class to calculate the crossing points of line segments.
    /// </summary>
    public class LineSegmentCrossingCalculator
    {
        /// <summary>
        /// Default CTOR
        /// </summary>
        public LineSegmentCrossingCalculator() 
        {
            m_crossings = new Dictionary<int[], Crossing<int, LineSegment<int>>> ();
            m_linesegments = new List<LineSegment<int>> ();
        }

        /// <summary>
        /// Adds a line segment to the m_linesegments and triggers the calculation of crossing points 
        /// with all lines segment already containing.
        /// Calculates crossing points with all line segments contained in m_linesegments.
        /// All found new crossing points are added to m_crossings.
        /// param lineSegment: the new line segment added to the list
        /// </summary>
        public void AddLinesegment(LineSegment<int> lineSegment)
        {
            foreach (LineSegment<int> linesegmentFromList in m_linesegments)
            {
                Crossing<int, LineSegment<int>>? crossing = CalculateCrossing(linesegmentFromList,ref lineSegment);
                if (crossing != null) 
                {
                    if (m_crossings.ContainsKey(crossing.Position))
                    {
                        m_crossings[crossing.Position].AddElement(ref lineSegment);
                    }
                    else
                    {
                        m_crossings.Add(crossing.Position, crossing);
                    }
                }
            }
            m_linesegments.Add(lineSegment);

        }

        /// <summary>
        /// Calculates the crossing point of two line segments in 2 dimensional space
        /// by solving:
        /// Cx = ASx + (AEx - ASx)t = BSx + (BEx - BSx)t
        /// Cy = ASy + (AEy - ASy)u = BSy + (BEy - BSy)u
        /// param linesegmentA: first of the two line segments.
        /// param linesegmentB: second of the two line segments.
        /// return: If an intersection exist the point of intersection (containing both line segments).
        ///         null otherwise.
        /// </summary>
        private Crossing<int, LineSegment<int>>? CalculateCrossing(LineSegment<int> linesegmentA, ref LineSegment<int> linesegmentB)
        {
            int Ax = linesegmentA.Start[0];
            int Ay = linesegmentA.Start[1];

            int Bx = linesegmentA.End[0];
            int By = linesegmentA.End[1];

            int Cx = linesegmentB.Start[0];
            int Cy = linesegmentB.Start[1];

            int Dx = linesegmentB.End[0];
            int Dy = linesegmentB.End[1];

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

            return new Crossing<int, LineSegment<int>>(new int[] { x, y }, new List<LineSegment<int>>() { linesegmentA, linesegmentB });
        }

        public Dictionary<int[], Crossing<int, LineSegment<int>>> Crossings { get => m_crossings; set => m_crossings = value; }
        public List<LineSegment<int>> Linesegments { get => m_linesegments; set => m_linesegments = value; }

        private Dictionary<int[], Crossing<int, LineSegment<int>>> m_crossings;
        private List<LineSegment<int>> m_linesegments;

    }
}
