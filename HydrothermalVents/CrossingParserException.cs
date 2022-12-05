// (c)2022 David Szammer. All rights reserved.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HydrothermalVents
{
    public class CrossingParserException : Exception 
    {
        public CrossingParserException()
        {
        }

        public CrossingParserException(string message)
            : base(message)
        {
        }

        public CrossingParserException(string message, Exception inner)
        : base(message, inner)
        {
        }
    }
}
