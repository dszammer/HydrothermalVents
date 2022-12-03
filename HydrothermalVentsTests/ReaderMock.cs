using HydrothermalVents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HydrothermalVentsTests
{
    public class ReaderMock : IIO
    {
        public ReaderMock(string[] lines)
        {
            m_lines = lines;
        }
        public string? ReadLine()
        {
            if (i < m_lines.Count())
                return m_lines[i++];
            return null;
        }
        public void WriteLine(string line)
        {
            throw new NotImplementedException();
        }

        int i = 0;
        string[] m_lines;
    }
}
