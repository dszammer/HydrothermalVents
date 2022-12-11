// (c)2022 David Szammer. All rights reserved.

using HydrothermalVents.BusinessLogic;

namespace HydrothermalVents.Parser
{
    public class CrossingsWriter<U, T> : ICrossingsWriter<U, T> where U : struct where T : class
    {
        public CrossingsWriter(ICrossingParser<U, T> parser, List<IIO> writers)
        {
            m_writers = writers;
            m_parser = parser;
        }

        public void writeCrossings(List<Crossing<U, T>> crossings)
        {
            foreach (IIO writer in m_writers)
            {
                writer.WriteLine($"Number of dangerous points: {crossings.Count}");

                foreach (Crossing<U, T> crossing in crossings)
                {
                    writer.WriteLine(m_parser.ToString(crossing));
                }
            }
        }

        List<IIO> m_writers;
        ICrossingParser<U, T> m_parser;
    }
}

