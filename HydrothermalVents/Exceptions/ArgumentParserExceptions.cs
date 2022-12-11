// (c)2022 David Szammer. All rights reserved.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HydrothermalVents.Exceptions
{
    public class ArgumentsParserException : Exception
    {
        public ArgumentsParserException()
        {
        }

        public ArgumentsParserException(string message)
            : base(message)
        {
        }

        public ArgumentsParserException(string message, Exception inner)
        : base(message, inner)
        {
        }
    }

    public class NoArgumentsException : ArgumentsParserException
    {
        public NoArgumentsException()
        {
        }

        public NoArgumentsException(string message)
            : base(message)
        {
        }

        public NoArgumentsException(string message, Exception inner)
        : base(message, inner)
        {
        }
    }

    public class BadArgumentFormatException : ArgumentsParserException
    {
        public BadArgumentFormatException()
        {
        }

        public BadArgumentFormatException(string message)
            : base(message)
        {
        }

        public BadArgumentFormatException(string message, Exception inner)
        : base(message, inner)
        {
        }
    }
}
