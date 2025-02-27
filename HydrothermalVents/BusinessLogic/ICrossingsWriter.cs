// (c)2022 David Szammer. All rights reserved.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HydrothermalVents.BusinessLogic
{
    /// <summary>
    /// Interface for writing the calculated crossings of elements.
    /// </summary>
    /// <typeparam name="U">The type of the coordinates, which must be a value type.</typeparam>
    /// <typeparam name="T">The type of the crossing elements, which must be a reference type.</typeparam>
    public interface ICrossingsWriter<U, T> where U : struct
                                            where T : class
    {
        /// <summary>
        /// Writes the list of calculated crossings.
        /// </summary>
        /// <param name="crossings">The list of <see cref="Crossing{U, T}"/> objects representing the calculated crossings.</param>
        public void writeCrossings(List<Crossing<U, T>> crossings);
    }
}
