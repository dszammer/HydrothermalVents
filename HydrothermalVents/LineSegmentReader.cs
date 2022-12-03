using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HydrothermalVents
{
    public class LineSegmentReader<T> : ILineSegmentReader<T> where T : struct
    {
        public LineSegmentReader(ILineSegmentParser<T> parser, List<IIO> readers) 
        {
            m_parser = parser;
            m_readers = readers;
            m_currentReaderIndex = 0;
        }

        public LineSegment<T> GetLineSegment()
        {
            do
            {
                string? line = m_readers[m_currentReaderIndex].ReadLine();

                if (line != null)
                    return m_parser.FromString(line);
                m_currentReaderIndex++;
            } while (m_currentReaderIndex < m_readers.Count());

            return null;
        }

        ILineSegmentParser<T> m_parser;
        List<IIO> m_readers;
        int m_currentReaderIndex = 0;
    }
}
