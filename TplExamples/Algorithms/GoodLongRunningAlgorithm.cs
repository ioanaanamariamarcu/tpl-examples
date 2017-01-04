using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TplExamples.Algorithms
{
    public class GoodLongRunningAlgorithm : IRenderingAlgorithm
    {
        private readonly int _lines;

        public GoodLongRunningAlgorithm(int lines)
        {
            _lines = lines;
        }
        static void MonitorNetwork()
        {
            // ... 
        }

        public void Calculate(object sender, DoWorkEventArgs e)
        {
            var worker = (BackgroundWorker)sender;
            //Parallel.For(0, _lines, new ParallelOptions { MaxDegreeOfParallelism = 4 }, (i) =>
            //{
            //    Thread.Sleep(500);
            //    worker.ReportProgress(0, new object[] { Thread.CurrentThread.ManagedThreadId, i, Thread.CurrentThread.IsThreadPoolThread });
            //});
        }
    }
}
