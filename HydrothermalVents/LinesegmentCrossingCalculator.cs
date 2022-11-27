using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HydrothermalVents
{
    public class LinesegmentCrossingCalculator
    {
        public LinesegmentCrossingCalculator() 
        {
            m_crossings = new List<Crossing<int, Linesegment<int>>> ();
            m_linesegments = new List<Linesegment<int>> ();
        }

        public void AddLinesegment(Linesegment<int> linesegment)
        {
            m_linesegments.Add(linesegment);
        }

        public List<Crossing<int, Linesegment<int>>> Crossings { get => m_crossings; set => m_crossings = value; }
        public List<Linesegment<int>> Linesegments { get => m_linesegments; set => m_linesegments = value; }

        private List<Crossing<int, Linesegment<int>>> m_crossings;
        private List<Linesegment<int>> m_linesegments;

    }
}
