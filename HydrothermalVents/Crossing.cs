using System;
using System.Collections.Generic;


namespace HydrothermalVents
{
    public class Crossing<U,T>  where U : struct
                                where T : class 
    {
        public Crossing()
        {
            m_position = new U[] { };
            m_elements = new List<T>();
        }
        public Crossing(U[] position, List<T> lines)
        {
            m_position = position;
            m_elements = lines;
        }

        public U[] Position { get => m_position; set => m_position = value; }
        public List<T> Elements { get => m_elements; set => m_elements = value; }


        public void AddLinesegement(ref T line)
        {
            m_elements.Add(line);
        }

        private U[] m_position;
        private List<T> m_elements;
    }
}
