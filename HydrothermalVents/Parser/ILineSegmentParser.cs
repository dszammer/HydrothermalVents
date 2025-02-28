// (c)2022 David Szammer. All rights reserved.

using HydrothermalVents.BusinessLogic;

namespace HydrothermalVents.Parser
{
    /// <summary>
    /// Defines methods for parsing and converting <see cref="LineSegment{T}"/> objects.
    /// </summary>
    /// <typeparam name="T">The type of the coordinates, which must be a value type.</typeparam>
    public interface ILineSegmentParser<T> where T : struct
    {
        /// <summary>
        /// Parses a string to create a <see cref="LineSegment{T}"/> object.
        /// </summary>
        /// <param name="input">The string representation of the line segment.</param>
        /// <returns>A <see cref="LineSegment{T}"/> object parsed from the input string.</returns>
        public LineSegment<T> FromString(string input);

        /// <summary>
        /// Converts a <see cref="LineSegment{T}"/> object to its string representation.
        /// </summary>
        /// <param name="input">The <see cref="LineSegment{T}"/> object to convert.</param>
        /// <returns>A string representation of the <see cref="LineSegment{T}"/> object.</returns>
        public string ToString(LineSegment<T> input);
    }
}
