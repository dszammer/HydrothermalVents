// (c)2022 David Szammer. All rights reserved.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HydrothermalVents
{
    public class LineSegmentException : Exception 
    {
        public LineSegmentException()
        {
        }

        public LineSegmentException(string message)
            : base(message)
        {
        }

        public LineSegmentException(string message, Exception inner)
        : base(message, inner)
        {
        }
    }
}
