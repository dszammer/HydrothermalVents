// (c)2022 David Szammer. All rights reserved.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HydrothermalVents.Parser;

namespace HydrothermalVents.IO
{
    public class ConsoleWriter : IIO
    {
        public string? ReadLine()
        {
            throw new NotImplementedException();
        }

        public void WriteLine(string line)
        {
            Console.WriteLine(line);
        }
    }
}
