using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HydrothermalVents
{
    public class FileWriter : IIO
    {
        public FileWriter(string path)
        {
            m_path = path;
            m_file = new StreamWriter(path);
        }

        ~FileWriter()
        {
            m_file.Close();
        }
        public string? ReadLine()
        {
            throw new NotImplementedException();
        }

        public void WriteLine(string line)
        {
            m_file.WriteLine(line);
        }

        private string m_path;
        private StreamWriter m_file;
    }
}
