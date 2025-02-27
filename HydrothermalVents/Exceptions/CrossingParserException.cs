﻿// (c)2022 David Szammer. All rights reserved.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HydrothermalVents.Exceptions
{
    /// <summary>
    /// Represents errors that occur during the parsing of crossing data.
    /// </summary>
    /// <remarks>
    /// The <see cref="CrossingParserException"/> class is thrown when an error occurs while parsing crossing data.
    /// This class provides constructors to create an exception with a specified error message and an inner exception that caused the current exception.
    /// </remarks>
    public class CrossingParserException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CrossingParserException"/> class.
        /// </summary>
        public CrossingParserException()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CrossingParserException"/> class with a specified error message.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        public CrossingParserException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CrossingParserException"/> class with a specified error message and a reference to the inner exception that is the cause of this exception.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <param name="inner">The exception that is the cause of the current exception, or a null reference if no inner exception is specified.</param>
        public CrossingParserException(string message, Exception inner)
        : base(message, inner)
        {
        }
    }
}
