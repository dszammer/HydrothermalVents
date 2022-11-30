using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace HydrothermalVents
{
    public class HydrothermalVentLineCrossings<U,T> where U: struct where T: struct
    {
        public HydrothermalVentLineCrossings(ref ILineSegmentReader<U> reader, ref ICrossingsWriter<T, LineSegment<U>> writer) 
        {
            m_reader = reader;
            m_writer = writer;

            m_calculator = new LineSegmentCrossingCalculator<U,T>();
        }

        public int CalculateAllLineSegementCrossings()
        {
            LineSegment<U>? linesegment;
            while ((linesegment = m_reader.GetLineSegment()) != null)
            {
                AddLinesegment(ref linesegment);
            }

             return m_crossings.Count;
        }
       
        /// <summary>
        /// Adds a line segment to the m_linesegments and triggers the calculation of crossing points 
        /// with all lines segment already containing.
        /// Calculates crossing points with all line segments contained in m_linesegments.
        /// All found new crossing points are added to m_crossings.
        /// param lineSegment: the new line segment added to the list
        /// </summary>
        private void AddLinesegment(ref LineSegment<U> lineSegment)
        {
            foreach (LineSegment<U> linesegmentFromList in m_linesegments)
            {
                Crossing<T, LineSegment<U>>? crossing = m_calculator.CalculateCrossing(linesegmentFromList, lineSegment);
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

        private ILineSegmentReader<U> m_reader;
        private ICrossingsWriter<T, LineSegment<U>> m_writer;
        private LineSegmentCrossingCalculator<U, T> m_calculator;

        public Dictionary<T[], Crossing<T, LineSegment<U>>> Crossings { get => m_crossings; set => m_crossings = value; }
        public List<LineSegment<U>> Linesegments { get => m_linesegments; set => m_linesegments = value; }

        private Dictionary<T[], Crossing<T, LineSegment<U>>> m_crossings;
        private List<LineSegment<U>> m_linesegments;
    }
}

