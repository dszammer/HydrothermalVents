using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HydrothermalVents.Parser
{
    /// <summary>
    /// Defines methods for reading and writing lines of text.
    /// </summary>
    public interface IIO
    {
        /// <summary>
        /// Reads a line of text.
        /// </summary>
        /// <returns>The line of text read, or <c>null</c> if no more lines are available.</returns>
        public string? ReadLine();

        /// <summary>
        /// Writes a line of text.
        /// </summary>
        /// <param name="line">The line of text to write.</param>
        public void WriteLine(string line);
    }
}
