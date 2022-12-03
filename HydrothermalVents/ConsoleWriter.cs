using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HydrothermalVents
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
