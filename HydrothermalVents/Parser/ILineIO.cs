// (c)2022 David Szammer. All rights reserved.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HydrothermalVents.Parser
{
    public interface ILineIO
    {
        public string readLine();
        public void writeLine(string line);
    }
}
