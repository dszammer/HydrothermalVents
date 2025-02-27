// (c)2022 David Szammer. All rights reserved.

using HydrothermalVents.BusinessLogic;

namespace HydrothermalVents.Parser
{
    /// <summary>
    /// Provides methods for writing the calculated crossings of elements to multiple output destinations.
    /// </summary>
    /// <typeparam name="U">The type of the coordinates, which must be a value type.</typeparam>
    /// <typeparam name="T">The type of the crossing elements, which must be a reference type.</typeparam>
    /// <remarks>
    /// The <see cref="CrossingsWriter{U, T}"/> class implements the <see cref="ICrossingsWriter{U, T}"/> interface
    /// to write the calculated crossings of elements to multiple output destinations using the provided writers.
    /// </remarks>
    public class CrossingsWriter<U, T> : ICrossingsWriter<U, T> where U : struct where T : class
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CrossingsWriter{U, T}"/> class with the specified parser and writers.
        /// </summary>
        /// <param name="parser">The parser used to convert crossings to string representations.</param>
        /// <param name="writers">The list of writers used to output the crossings.</param>
        public CrossingsWriter(ICrossingParser<U, T> parser, List<IIO> writers)
        {
            m_writers = writers;
            m_parser = parser;
        }

        /// <summary>
        /// Writes the list of calculated crossings to the output destinations.
        /// </summary>
        /// <param name="crossings">The list of <see cref="Crossing{U, T}"/> objects representing the calculated crossings.</param>
        public void writeCrossings(List<Crossing<U, T>> crossings)
        {
            foreach (IIO writer in m_writers)
            {
                writer.WriteLine($"Number of dangerous points: {crossings.Count}");

                foreach (Crossing<U, T> crossing in crossings)
                {
                    writer.WriteLine(m_parser.ToString(crossing));
                }
            }
        }

        private List<IIO> m_writers;
        private ICrossingParser<U, T> m_parser;
    }
}

