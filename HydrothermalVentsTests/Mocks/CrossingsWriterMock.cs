// (c)2022 David Szammer. All rights reserved.

using HydrothermalVents.BusinessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HydrothermalVentsTests
{
    /// <summary>
    /// A mock implementation of the <see cref="ICrossingsWriter{U, T}"/> interface for testing purposes.
    /// </summary>
    /// <typeparam name="U">The type of the coordinates, which must be a value type.</typeparam>
    /// <typeparam name="T">The type of the crossing elements, which must be a reference type.</typeparam>
    public class CrossingsWriterMock<U, T> : ICrossingsWriter<U, T> where U : struct where T : class
    {
        /// <summary>
        /// Simulates the writing of crossing.
        /// </summary>
        /// <param name="crossings">The list of crossings to write.</param>
        public void writeCrossings(List<Crossing<U, T>> crossings) { m_written = true; }

        /// <summary>
        /// Indicates whether the crossings have been written.
        /// </summary>
        public bool m_written = false;
    }
}
