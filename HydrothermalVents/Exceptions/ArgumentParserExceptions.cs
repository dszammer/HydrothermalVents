// (c)2022 David Szammer. All rights reserved.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HydrothermalVents.Exceptions
{
    /// <summary>
    /// Represents errors that occur during the parsing of arguments.
    /// </summary>
    /// <remarks>
    /// The <see cref="ArgumentsParserException"/> class is the base class for exceptions that are thrown
    /// when an error occurs while parsing arguments. This class provides constructors to create an exception
    /// with a specified error message and an inner exception that caused the current exception.
    /// </remarks>
    public class ArgumentsParserException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ArgumentsParserException"/> class.
        /// </summary>
        public ArgumentsParserException()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ArgumentsParserException"/> class with a specified error message.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        public ArgumentsParserException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ArgumentsParserException"/> class with a specified error message and a reference to the inner exception that is the cause of this exception.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <param name="inner">The exception that is the cause of the current exception, or a null reference if no inner exception is specified.</param>
        public ArgumentsParserException(string message, Exception inner)
        : base(message, inner)
        {
        }
    }

    /// <summary>
    /// Represents an error that occurs when no arguments are provided.
    /// </summary>
    /// <remarks>
    /// The <see cref="NoArgumentsException"/> class is thrown when an operation requires arguments but none are provided.
    /// This class extends the <see cref="ArgumentsParserException"/> class.
    /// </remarks>
    public class NoArgumentsException : ArgumentsParserException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NoArgumentsException"/> class.
        /// </summary>
        public NoArgumentsException()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="NoArgumentsException"/> class with a specified error message.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        public NoArgumentsException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="NoArgumentsException"/> class with a specified error message and a reference to the inner exception that is the cause of this exception.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <param name="inner">The exception that is the cause of the current exception, or a null reference if no inner exception is specified.</param>
        public NoArgumentsException(string message, Exception inner)
        : base(message, inner)
        {
        }
    }

    /// <summary>
    /// Represents an error that occurs when an argument is in an invalid format.
    /// </summary>
    /// <remarks>
    /// The <see cref="BadArgumentFormatException"/> class is thrown when an argument does not meet the expected format.
    /// This class extends the <see cref="ArgumentsParserException"/> class.
    /// </remarks>
    public class BadArgumentFormatException : ArgumentsParserException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BadArgumentFormatException"/> class.
        /// </summary>
        public BadArgumentFormatException()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BadArgumentFormatException"/> class with a specified error message.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        public BadArgumentFormatException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BadArgumentFormatException"/> class with a specified error message and a reference to the inner exception that is the cause of this exception.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <param name="inner">The exception that is the cause of the current exception, or a null reference if no inner exception is specified.</param>
        public BadArgumentFormatException(string message, Exception inner)
        : base(message, inner)
        {
        }
    }
}
