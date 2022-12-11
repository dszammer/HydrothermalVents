// (c)2022 David Szammer. All rights reserved.

using HydrothermalVents.Parser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HydrothermalVentsTests
{
    public class WriterMock : IIO
    {
        public string? ReadLine()
        {
            throw new NotImplementedException();
        }
        public void WriteLine(string line)
        {
            m_written++;
        }

        public int m_written = 0;
    }
}
