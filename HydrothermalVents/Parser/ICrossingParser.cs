using HydrothermalVents.BusinessLogic;
using HydrothermalVents.Exceptions;

namespace HydrothermalVents.Parser
{
    /// <summary>
    /// Defines methods for parsing and converting <see cref="Crossing{T, U}"/> objects.
    /// </summary>
    /// <typeparam name="T">The type of the crossing elements, which must be a value type.</typeparam>
    /// <typeparam name="U">The type of the coordinates, which must be a reference type.</typeparam>
    public interface ICrossingParser<T, U> where T : struct where U : class
    {
        /// <summary>
        /// Parses a string to create a <see cref="Crossing{T, U}"/> object.
        /// </summary>
        /// <param name="input">The string representation of the crossing.</param>
        /// <returns>A <see cref="Crossing{T, U}"/> object parsed from the input string.</returns>
        public Crossing<T, U> FromString(string input);

        /// <summary>
        /// Converts a <see cref="Crossing{T, U}"/> object to its string representation.
        /// </summary>
        /// <param name="crossing">The <see cref="Crossing{T, U}"/> object to convert.</param>
        /// <returns>A string representation of the <see cref="Crossing{T, U}"/> object.</returns>
        public string ToString(Crossing<T, U> crossing);
    }
}
