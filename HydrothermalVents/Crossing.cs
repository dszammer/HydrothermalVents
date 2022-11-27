using System;
using System.Collections.Generic;


namespace HydrothermalVents
{
    public class Crossing<T> where T : struct
    {
        public Crossing()
        {
            m_position = new T[] { };
            m_lines = new List<Linesegment<T>>();
        }
        public Crossing(T[] position, List<Linesegment<T>> lines)
        {
            m_position = position;
            m_lines = lines;
        }

        public T[] Position { get => m_position; set => m_position = value; }
        public List<Linesegment<T>> Lines { get => m_lines; set => m_lines = value; }


        public void AddLinesegement(ref Linesegment<T> line)
        {
            m_lines.Add(line);
        }

        private T[] m_position;
        private List<Linesegment<T>> m_lines;
    }
}
