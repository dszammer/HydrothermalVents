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
    public class WriterMock : IIO
    {
        /// <summary>
        /// Reads a line of text.
        /// </summary>
        /// <returns>Always throws a <see cref="NotImplementedException"/>.</returns>
        /// <exception cref="NotImplementedException">Thrown when the method is not implemented.</exception>
        public string? ReadLine()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Writes a line of text.
        /// </summary>
        /// <param name="line">The line of text to write.</param>
        public void WriteLine(string line)
        {
            m_written++;
        }

        /// <summary>
        /// The number of lines written.
        /// </summary>
        public int m_written = 0;
    }
}
