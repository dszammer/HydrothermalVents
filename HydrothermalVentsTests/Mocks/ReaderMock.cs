// (c)2022 David Szammer. All rights reserved.

using HydrothermalVents.Parser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HydrothermalVentsTests
{
    /// <summary>
    /// A mock implementation of the <see cref="IIO"/> interface for testing purposes.
    /// </summary>
    public class ReaderMock : IIO
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ReaderMock"/> class with the specified lines.
        /// </summary>
        /// <param name="lines">The lines of text to read.</param>
        public ReaderMock(string[] lines)
        {
            m_lines = lines;
        }

        /// <summary>
        /// Reads a line of text.
        /// </summary>
        /// <returns>The line of text read, or <c>null</c> if no more lines are available.</returns>
        public string? ReadLine()
        {
            if (i < m_lines.Count())
                return m_lines[i++];
            return null;
        }

        /// <summary>
        /// Writes a line of text.
        /// </summary>
        /// <param name="line">The line of text to write.</param>
        /// <exception cref="NotImplementedException">Thrown when the method is not implemented.</exception>
        public void WriteLine(string line)
        {
            throw new NotImplementedException();
        }

        int i = 0;
        string[] m_lines;
    }
}
