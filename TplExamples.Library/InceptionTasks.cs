using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TplExamples.Library
{
    public class InceptionTasks
    {
        const string FilePath = @"C:\doc\prezentare async programming in .net\TplExamples\TplExamples.Console\XmlFeedProduct.xml";
       public async Task<string> CallingAnotherTask()
        {
            TplLogger.Log("CallingAnotherTask");
            return await AnotherTask();
        }

        async Task<string> AnotherTask()
        {
            var ioClient = new IoClientAsync(FilePath);
            TplLogger.Log("AnotherTask");
            return await ioClient.ReadTwoLinesWithLoggingAsync();
        }
    }
}
