﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TplExamples.Algorithms
{
    class ParallelAlgorithm : IRenderingAlgorithm
    {
        private readonly int _lines;

        public ParallelAlgorithm(int lines)
        {
            _lines = lines;
        }

        public void Calculate(object sender, DoWorkEventArgs e)
        {
            var worker = (BackgroundWorker)sender;
            Parallel.For(0, _lines, (i) =>
            {
                Thread.Sleep(10);
                worker.ReportProgress(0, new object[] { Thread.CurrentThread.ManagedThreadId, i, Thread.CurrentThread.IsThreadPoolThread });
            });
        }
    }
}
