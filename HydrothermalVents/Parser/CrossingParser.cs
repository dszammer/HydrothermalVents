// (c)2022 David Szammer. All rights reserved.

using System;
using System.Collections.Generic;

using HydrothermalVents.BusinessLogic;
using HydrothermalVents.Exceptions;

namespace HydrothermalVents.Parser
{
    /// <summary>
    /// Provides methods for parsing and formatting crossing points of line segments.
    /// </summary>
    /// <remarks>
    /// The <see cref="CrossingParser"/> class implements the <see cref="ICrossingParser{int, LineSegment{int}}"/> interface
    /// to parse and format crossing points of line segments in 2-dimensional space.
    /// </remarks>
    public class CrossingParser : ICrossingParser<int, LineSegment<int>>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CrossingParser"/> class.
        /// </summary>
        public CrossingParser() { }

        /// <summary>
        /// Converts a <see cref="Crossing{int, LineSegment{int}}"/> object to its string representation.
        /// </summary>
        /// <param name="crossing">The crossing point to convert to a string.</param>
        /// <returns>
        /// A string representation of the crossing point in the format "(x,y) -> count",
        /// where x and y are the coordinates of the crossing point, and count is the number of elements crossing at that point.
        /// </returns>
        public string ToString(Crossing<int, LineSegment<int>> crossing)
        {
            return $"({crossing.Position[0]},{crossing.Position[1]}) -> {crossing.Elements.Count}";
        }

        /// <summary>
        /// Parses a string to create a <see cref="Crossing{int, LineSegment{int}}"/> object.
        /// </summary>
        /// <param name="input">The string representation of the crossing point.</param>
        /// <returns>
        /// A <see cref="Crossing{int, LineSegment{int}}"/> object representing the parsed crossing point.
        /// </returns>
        /// <exception cref="CrossingParserException">Thrown when the method is not implemented.</exception>
        public Crossing<int, LineSegment<int>> FromString(string input)
        {
            throw new CrossingParserException("Not implemented", new NotImplementedException());
        }
    }
}
