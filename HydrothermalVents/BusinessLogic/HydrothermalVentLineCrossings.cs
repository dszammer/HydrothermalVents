// (c)2022 David Szammer. All rights reserved.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HydrothermalVents.BusinessLogic;

namespace HydrothermalVents
{
    /// <summary>
    /// Core business logic class for calculating all crossing points of the provided line segments.
    /// </summary>
    /// <typeparam name="U">The type of the coordinates, which must be a value type.</typeparam>
    /// <typeparam name="T">The type of the crossing elements, which must be a value type.</typeparam>
    /// <remarks>
    /// The <see cref="HydrothermalVentLineCrossings{U, T}"/> class uses various interfaces to read line segments, calculate crossings, and optionally paint and write the results.
    /// </remarks>
    public class HydrothermalVentLineCrossings<U, T> where U : struct where T : struct
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="HydrothermalVentLineCrossings{U, T}"/> class with the specified interfaces.
        /// </summary>
        /// <param name="calculator">The calculator used to determine the crossings of line segments.</param>
        /// <param name="reader">The reader used to fetch line segments.</param>
        /// <param name="writer">The writer used to output the crossings (optional).</param>
        /// <param name="painter">The painter used to visualize the line segments and crossings (optional).</param>
        public HydrothermalVentLineCrossings(ICrossingCalculator<T, LineSegment<U>> calculator, ILineSegmentReader<U> reader, ICrossingsWriter<T, LineSegment<U>>? writer, ILineSegmentCrossingPainter<T,LineSegment<U>>? painter)
        {
            m_reader = reader;
            m_writer = writer;
            m_calculator = calculator;
            m_painter = painter;
            m_linesegments = new List<LineSegment<U>>();
            m_crossings = new Dictionary<T[], Crossing<T, LineSegment<U>>>();
        }

        /// <summary>
        /// Fetches line segments from the provided reader until exhausted and calculates all crossing points.
        /// </summary>
        /// <returns>The final number of line segment crossings.</returns>
        public int CalculateAllLineSegementCrossings()
        {
            LineSegment<U>? lineSegment;
            while ((lineSegment = m_reader.GetLineSegment()) != null)
            {
                if(m_calculator.LineSegmentSatisfiesConstraints(lineSegment))
                {
                    CalculateAllCrossings(lineSegment);
                    m_linesegments.Add(lineSegment);
                }
            }

            PaintAllLineSegementsAndCrossings();
            WriteAllLineSegementCrossings();

            return m_crossings.Count;
        }

        /// <summary>
        /// Passes all line segments and crossings to the painter.
        /// </summary>
        public void PaintAllLineSegementsAndCrossings()
        {
            if (m_painter!= null)
                m_painter.draw(m_linesegments, m_crossings.Values.ToList());
        }

        /// <summary>
        /// Passes all crossings to the writer.
        /// </summary>
        public void WriteAllLineSegementCrossings()
        {
            if (m_writer!= null)
                m_writer.writeCrossings(m_crossings.Values.ToList());
        }


        /// <summary>
        /// Calculates crossing points with all line segments contained in m_linesegments.
        /// All found new crossing points are added to m_crossings.
        /// </summary>
        /// <param name="lineSegment">The new line segment.</param>
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

        private ILineSegmentReader<U> m_reader;
        private ICrossingsWriter<T, LineSegment<U>>? m_writer;
        private ILineSegmentCrossingPainter<T, LineSegment<U>>? m_painter;
        private ICrossingCalculator<T, LineSegment<U>> m_calculator;

        private Dictionary<T[], Crossing<T, LineSegment<U>>> m_crossings;
        private List<LineSegment<U>> m_linesegments;
    }
}

