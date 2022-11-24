using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace HydrothermalVents
{
    public class Line<T> where T : struct
    {
        private Vector<T> m_start;
        private Vector<T> m_end;

        public Line(Vector<T> start, Vector<T> end)
        {
            m_start = start;
            m_end = end;
        }
    }
}
