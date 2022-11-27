using System;
using System.Collections.Generic;


namespace HydrothermalVents
{
    public class Linesegment<T> where T : struct
    {
        public Linesegment(T[] start, T[] end)
        {
            m_start = start;
            m_end = end;
        }

        public T[] Start { get => m_start; set => m_start = value; }
        public T[] End { get => m_end; set => m_end = value; }

        private T[] m_start;
        private T[] m_end;
    }
}
