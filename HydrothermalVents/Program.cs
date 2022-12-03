using System;

namespace HydrothermalVents // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static int Main(string[] args)
        {
            List<IIO> writers = new List<IIO> { new ConsoleWriter(), new FileWriter("test.txt") };


            return 0;
        }
    }
}

