using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HydrothermalVents
{
    public interface IIO
    {
        public string? ReadLine();
        public void WriteLine(string line);
    }
}
