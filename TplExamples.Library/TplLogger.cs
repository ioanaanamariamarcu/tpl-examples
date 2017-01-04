using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TplExamples.Library
{
    public class TplLogger
    {
        public static void Log(string op)
        {
            int wt, ct;
            ThreadPool.GetAvailableThreads(out wt, out ct);
            Console.WriteLine(op + ": Id=" + Thread.CurrentThread.ManagedThreadId + "; TaskId:"+Task.CurrentId+" Available wt=" + wt + ";ct=" + ct);
        }
    }
}
