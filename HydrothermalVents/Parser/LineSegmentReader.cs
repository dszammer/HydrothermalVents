// (c)2022 David Szammer. All rights reserved.

using HydrothermalVents.BusinessLogic;

namespace HydrothermalVents.Parser
{
    /// <summary>
    /// Provides methods to read <see cref="LineSegment{T}"/> objects from multiple readers.
    /// </summary>
    /// <typeparam name="T">The type of the coordinates, which must be a value type.</typeparam>
    public class LineSegmentReader<T> : ILineSegmentReader<T> where T : struct
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LineSegmentReader{T}"/> class with the specified parser and readers.
        /// </summary>
        /// <param name="parser">The parser used to parse line segments.</param>
        /// <param name="readers">The list of readers to read lines of text from.</param>
        public LineSegmentReader(ILineSegmentParser<T> parser, List<IIO> readers)
        {
            m_parser = parser;
            m_readers = readers;
            m_currentReaderIndex = 0;
        }

        /// <summary>
        /// Fetches the next line segment.
        /// </summary>
        /// <returns>A <see cref="LineSegment{T}"/> object representing the next line segment, or <c>null</c> if no more line segments are available.</returns>
        public LineSegment<T>? GetLineSegment()
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
