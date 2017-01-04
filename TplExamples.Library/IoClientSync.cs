using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TplExamples.Library
{
    class IoClientSync
    {
        private readonly string _filePath;
        private StreamReader _reader = null;
        private StreamReader Reader
        {
            get
            {
                if (_reader == null) _reader = File.OpenText(_filePath);
                return _reader;
            }
        }

        public IoClientSync(string filePath)
        {
            _filePath = filePath;
        }

        public string ReadLine()
        {
            return Reader.ReadLine();
        }
    }
}
