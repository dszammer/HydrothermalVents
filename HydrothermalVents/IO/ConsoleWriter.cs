// (c)2022 David Szammer. All rights reserved.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HydrothermalVents.Parser;

namespace HydrothermalVents.IO
{
    /// <summary>
    /// Provides methods for writing to and reading from the console.
    /// </summary>
    /// <remarks>
    /// The <see cref="ConsoleWriter"/> class implements the <see cref="IIO"/> interface to provide console input and output functionality.
    /// </remarks>
    public class ConsoleWriter : IIO
    {
        /// <summary>
        /// Reads a line of input from the console.
        /// </summary>
        /// <returns>
        /// A string containing the next line of input from the console, or <c>null</c> if no input is available.
        /// </returns>
        /// <exception cref="NotImplementedException">Thrown when the method is not implemented.</exception>
        public string? ReadLine()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Writes a line of text to the console.
        /// </summary>
        /// <param name="line">The line of text to write to the console.</param>
        public void WriteLine(string line)
        {
            Console.WriteLine(line);
        }
    }
}
