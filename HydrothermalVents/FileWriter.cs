using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HydrothermalVents
{
    public class FileReader : IIO
    {
        public FileReader(string path)
        {
            m_path = path;
            m_file = new StreamReader(path);
        }

        ~FileReader()
        {
            m_file.Close();
        }
        public string? ReadLine()
        {
            return m_file.ReadLine();
        }

        public void WriteLine(string line)
        {
            throw new NotImplementedException();
        }

        private string m_path;
        private StreamReader m_file;
    }
}
