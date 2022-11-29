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

            m_calculator = new LineSegmentCrossingCalculator();
        }

        public int CalculateAllLineSegementCrossings()
        {
            LineSegment<U>? linesegment;
            while ((linesegment = m_reader.GetLineSegment()) != null)
            {
                m_calculator.AddLinesegment(linesegment);
            }

             return m_calculator.Crossings.Count;
        }

        private ILineSegmentReader<U> m_reader;
        private ICrossingsWriter<T, LineSegment<U>> m_writer;
        private LineSegmentCrossingCalculator m_calculator;
    }
}

