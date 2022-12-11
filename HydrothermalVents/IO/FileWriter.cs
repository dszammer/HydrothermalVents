// (c)2022 David Szammer. All rights reserved.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HydrothermalVents.Parser;

namespace HydrothermalVents.IO
{
    public class FileWriter : IIO
    {
        public FileWriter(string path)
        {
            m_path = path;
        }

        ~FileWriter()
        {
        }
        public string? ReadLine()
        {
            throw new NotImplementedException();
        }

        public void WriteLine(string line)
        {
            m_file = new StreamWriter(m_path);
            m_file.WriteLine(line);
            m_file.Close();
        }

        private string m_path;
        private StreamWriter m_file;
    }
}
