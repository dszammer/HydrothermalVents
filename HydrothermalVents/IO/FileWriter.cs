// (c)2022 David Szammer. All rights reserved.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HydrothermalVents.Parser;

namespace HydrothermalVents.IO
{
    /// <summary>
    /// Provides methods for writing to a file.
    /// </summary>
    /// <remarks>
    /// The <see cref="FileWriter"/> class implements the <see cref="IIO"/> interface to provide file output functionality.
    /// </remarks>
    public class FileWriter : IIO, IDisposable
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FileWriter"/> class with the specified file path.
        /// </summary>
        /// <param name="path">The path to the file to be written to.</param>
        public FileWriter(string path)
        {
            m_path = path;
            m_file = new StreamWriter(m_path);
        }

        /// <summary>
        /// Finalizes an instance of the <see cref="FileWriter"/> class.
        /// </summary>
        ~FileWriter()
        {
            Dispose(false);
        }

        /// <summary>
        /// Reads a line of input from the file.
        /// </summary>
        /// <returns>
        /// A string containing the next line of input from the file, or <c>null</c> if no input is available.
        /// </returns>
        /// <exception cref="NotImplementedException">Thrown when the method is not implemented.</exception>
        public string? ReadLine()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Writes a line of text to the file.
        /// </summary>
        /// <param name="line">The line of text to write to the file.</param>
        /// <remarks>
        /// This method opens the file, writes the specified line, and then closes the file.
        /// </remarks>
        public void WriteLine(string line)
        {
            m_file.WriteLine(line);
            m_file.Flush();
        }

        /// <summary>
        /// Releases all resources used by the <see cref="FileWriter"/> object.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Releases the unmanaged resources used by the <see cref="FileWriter"/> and optionally releases the managed resources.
        /// </summary>
        /// <param name="disposing">A boolean value indicating whether to release both managed and unmanaged resources.</param>
        protected virtual void Dispose(bool disposing)
        {
            if (!m_disposed)
            {
                if (disposing)
                {
                    // Dispose managed resources.
                    m_file?.Dispose();
                }

                // Dispose unmanaged resources.
                m_disposed = true;
            }
        }

        private string m_path;
        private StreamWriter m_file;
        private bool m_disposed = false;

    }
}
