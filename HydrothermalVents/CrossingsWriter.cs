using HydrothermalVents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HydrothermalVents
{
    public class CrossingsWriter<U, T> : ICrossingsWriter<U,T> where U : struct where T : class
    {
        public CrossingsWriter(ICrossingParser<U,T> parser, List<IIO> writers)
        {
            m_writers = writers;
            m_parser = parser;
        }
        
        public void writeCrossings(List<Crossing<U, T>> crossings)
        {
            foreach (Crossing<U, T> crossing in crossings) 
            {
                foreach (IIO writer in m_writers)
                {
                    writer.WriteLine(m_parser.ToString(crossing));
                }
            }
        }

        List<IIO> m_writers;
        ICrossingParser<U, T> m_parser;
    }
}

