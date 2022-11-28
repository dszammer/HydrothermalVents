using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HydrothermalVents
{
    public class LinesegmentException : Exception 
    {
        public LinesegmentException()
        {
        }

        public LinesegmentException(string message)
            : base(message)
        {
        }

        public LinesegmentException(string message, Exception inner)
        : base(message, inner)
        {
        }
    }
}
