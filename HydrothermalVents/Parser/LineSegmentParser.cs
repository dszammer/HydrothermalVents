// (c)2022 David Szammer. All rights reserved.

using HydrothermalVents.BusinessLogic;
using HydrothermalVents.Exceptions;

namespace HydrothermalVents.Parser
{

    /// <summary>
    /// Provides methods to parse and convert <see cref="LineSegment{T}"/> objects.
    /// </summary>
    public class LineSegmentParser : ILineSegmentParser<int>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LineSegmentParser"/> class.
        /// </summary>
        public LineSegmentParser() { }

        /// <summary>
        /// Parses a string to create a <see cref="LineSegment{int}"/> object.
        /// </summary>
        /// <param name="input">The string representation of the line segment.</param>
        /// <returns>A <see cref="LineSegment{int}"/> object parsed from the input string.</returns>
        /// <exception cref="LineSegmentParserException">Thrown when the input format is invalid.</exception>
        public LineSegment<int> FromString(string input)
        {
            try
            {
                string[] inputs = input.Replace(" -> ", ",").Split(","); // "X1,Y1 -> X2,Y2" => "X1,Y1,X2,Y2" => ["X1","Y1","X2","Y2"]
                return new LineSegment<int>(new int[] { int.Parse(inputs[0]), int.Parse(inputs[1]) }, new int[] { int.Parse(inputs[2]), int.Parse(inputs[3]) });
            }
            catch (Exception ex)
            {
                throw new LineSegmentParserException("Bad input format.", ex);
            }
        }

        /// <summary>
        /// Converts a <see cref="LineSegment{int}"/> object to its string representation.
        /// </summary>
        /// <param name="input">The <see cref="LineSegment{int}"/> object to convert.</param>
        /// <returns>A string representation of the <see cref="LineSegment{int}"/> object.</returns>
        /// <exception cref="LineSegmentParserException">Thrown when the method is not implemented.</exception>
        public string ToString(LineSegment<int> input)
        {
            throw new LineSegmentParserException("Not implemented");
        }
    }
}
