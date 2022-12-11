// (c)2022 David Szammer. All rights reserved.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HydrothermalVents.Exceptions
{
    public class LineSegmentParserException : Exception
    {
        public LineSegmentParserException()
        {
        }

        public LineSegmentParserException(string message)
            : base(message)
        {
        }

        public LineSegmentParserException(string message, Exception inner)
        : base(message, inner)
        {
        }
    }
}
