using System;
using System.ComponentModel;
using System.Drawing;
using System.Threading;

namespace TplExamples.Algorithms
{
    public class SequentialAlgorithm : IRenderingAlgorithm
    {
        private readonly int _lines;

        public SequentialAlgorithm(int lines)
        {
            _lines = lines;
        }

        public void Calculate(Object sender, DoWorkEventArgs e)
        {
            var worker = (BackgroundWorker)sender;
            for (int i = 0; i < _lines; i++)
            {
                Thread.Sleep(10);
                worker.ReportProgress(i, new object[] {0, i, true});
            }
        }
    }
}
