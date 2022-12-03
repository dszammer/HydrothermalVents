using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HydrothermalVents
{
    /// <summary>
    /// Core BL class
    /// Calculates all crossing points of the provided line segments.
    /// </summary>
    public class HydrothermalVentLineCrossings<U, T> where U : struct where T : struct
    {
        /// <summary>
        /// CTOR
        /// Provide interfaces to the IOParsers
        /// </summary>
        public HydrothermalVentLineCrossings(ref ILineSegmentReader<U> reader, ref ICrossingsWriter<T, LineSegment<U>> writer, ref ICrossingCalculator<T, LineSegment<U>> calculator)
        {
            m_reader = reader;
            m_writer = writer;
            m_calculator = calculator;

            m_linesegments = new List<LineSegment<U>>();
            m_crossings = new Dictionary<T[], Crossing<T, LineSegment<U>>>();
        }

        /// <summary>
        /// Fetches line segments from the provided reader until exhausted.
        /// Crossings of each new line segment are calculated with all previously read line segments.
        
        /// return: the final number of line segment crossings
        /// </summary>
        public int CalculateAllLineSegementCrossings()
        {
            LineSegment<U>? lineSegment;
            while ((lineSegment = m_reader.GetLineSegment()) != null)
            {
                CalculateAllCrossings(lineSegment);
                m_linesegments.Add(lineSegment);
            }

            return m_crossings.Count;
        }

        /// <summary>
        /// All line segments and crossings are passed to the painter
        /// </summary>
        public void PaintAllLineSegementsAndCrossings()
        {
            //TODO
        }

        /// <summary>
        /// All crossings are passed to the writer.
        /// </summary>
        public void WriteAllLineSegementCrossings()
        {
            m_writer.writeCrossings(m_crossings.Values.ToList());
        }

        /// <summary>
        /// Calculates crossing points with all line segments contained in m_linesegments.
        /// All found new crossing points are added to m_crossings.
        /// param lineSegment: the new line segment.
        /// </summary>
        private void CalculateAllCrossings(LineSegment<U> lineSegment)
        {
            foreach (LineSegment<U> linesegmentFromList in m_linesegments)
            {
                Crossing<T, LineSegment<U>>? crossing = m_calculator.CalculateCrossing(linesegmentFromList, lineSegment);
                if (crossing != null)
                {
                    if (m_crossings.ContainsKey(crossing.Position))
                    {
                        m_crossings[crossing.Position].AddElement(lineSegment);
                    }
                    else
                    {
                        m_crossings.Add(crossing.Position, crossing);
                    }
                }
            }
        }
        public Dictionary<T[], Crossing<T, LineSegment<U>>> Crossings { get => m_crossings; set => m_crossings = value; }
        public List<LineSegment<U>> Linesegments { get => m_linesegments; set => m_linesegments = value; }

        private ILineSegmentReader<U> m_reader;
        private ICrossingsWriter<T, LineSegment<U>> m_writer;

        private ICrossingCalculator<T, LineSegment<U>> m_calculator;

        private Dictionary<T[], Crossing<T, LineSegment<U>>> m_crossings;
        private List<LineSegment<U>> m_linesegments;
    }
}

