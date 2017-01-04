using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TplExamples.Library
{
    public class IoClientAsync
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

        public IoClientAsync(string filePath)
        {
            _filePath = filePath;
        }

        public async Task<string> ReadLineAsync()
        {
            await Task.Delay(10);
            return await Reader.ReadLineAsync();
        }

        public async Task<string> ReadOneLineWithLoggingAsync()
        {
            TplLogger.Log("ReadOneLineWithLoggingAsync1");
            await Task.Delay(10);
            TplLogger.Log("ReadOneLineWithLoggingAsync2");
            return await Reader.ReadLineAsync();
        }

        public async Task<string> ReadTwoLinesWithLoggingAsync()
        {
            TplLogger.Log("ReadLineAsync1");
            var line1 = await ReadOneLineWithLoggingAsync();
            TplLogger.Log("ReadLineAsync2");
            var line2 = await ReadOneLineWithLoggingAsync();
            TplLogger.Log("ReadLineAsync3");
            return line1 + line2;
        }
    }
}
