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
    /// Provides methods for reading from a file.
    /// </summary>
    /// <remarks>
    /// The <see cref="FileReader"/> class implements the <see cref="IIO"/> interface to provide file input functionality.
    /// </remarks>
    public class FileReader : IIO
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FileReader"/> class with the specified file path.
        /// </summary>
        /// <param name="path">The path to the file to be read.</param>
        public FileReader(string path)
        {
            m_path = path;
            m_file = new StreamReader(path);
        }

        /// <summary>
        /// Finalizes an instance of the <see cref="FileReader"/> class.
        /// </summary>
        ~FileReader()
        {
            m_file.Close();
        }

        /// <summary>
        /// Reads a line of text from the file.
        /// </summary>
        /// <returns>
        /// A string containing the next line of text from the file, or <c>null</c> if no more lines are available.
        /// </returns>
        public string? ReadLine()
        {
            return m_file.ReadLine();
        }

        /// <summary>
        /// Writes a line of text to the file.
        /// </summary>
        /// <param name="line">The line of text to write to the file.</param>
        /// <exception cref="NotImplementedException">Thrown when the method is not implemented.</exception>
        public void WriteLine(string line)
        {
            throw new NotImplementedException();
        }

        private string m_path;
        private StreamReader m_file;
    }
}
