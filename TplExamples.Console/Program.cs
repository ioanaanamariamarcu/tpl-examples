using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TplExamples.Library;

namespace TplExamples.Console
{
    class Program
    {
        const string FilePath = @"C:\doc\prezentare async programming in .net\TplExamples\TplExamples.Console\XmlFeedProduct.xml";
        static void Main(string[] args)
        {
            var opt = System.Console.ReadKey();
            switch (opt.KeyChar)
            {
                case '1':
                    Task1();
                    break;
                case '2':
                    Task2();
                    break;
                case '3':
                    TaskCallingTasks(); break;
                case '4':
                    LongRunningTask(); break;
                case 'c': CancellableTask();break;
                case 'i':
                    IoClient();
                    break;
            }

            System.Console.ReadKey();
        }

        static void IoClient()
        {
            var ioClient = new IoClientAsync(FilePath);
            for (var i = 0; i < 10; i++)
            {
                var t = ioClient.ReadLineAsync();
                t.Wait();
                System.Console.WriteLine(t.Result);
            }
        }

        static void Task1()
        {
            var t = new Task(() => { System.Console.WriteLine("Hello world!"); });
            t.Start();
            t.Wait();
        }
        static void Task2()
        {
            var t = Task.Run(() => { System.Console.WriteLine("Hello world!"); });
            t.Wait();
        }

        static void TaskCallingTasks()
        {
            int wt, ct;
            ThreadPool.GetMaxThreads(out wt, out ct);
            System.Console.WriteLine("max wt:" + wt + "; max cp:" + ct);
            TplLogger.Log("Before");
            var t = new InceptionTasks().CallingAnotherTask().Result;
            TplLogger.Log("After");
            System.Console.WriteLine("Result:" + t);
        }

        static void LongRunningTask()
        {
            var t = Task.Factory.StartNew(() => { System.Console.WriteLine("Hello world!"); },
                TaskCreationOptions.LongRunning);
            t.Wait();
        }

        static void CancellableTask()
        {
            var tokenSource = new CancellationTokenSource();
            try
            {
                var t = Task.Factory.StartNew(() =>
                    {
                        while (true)
                        {
                            tokenSource.Token.ThrowIfCancellationRequested();
                            System.Console.WriteLine("Hold the door.");
                            Thread.Sleep(300);
                        }
                    }, tokenSource.Token);
                Thread.Sleep(400);
                tokenSource.Cancel();
                t.Wait();
            }
            catch (AggregateException ex)
            {
                foreach (var innerException in ex.Flatten().InnerExceptions)
                {
                    System.Console.WriteLine("Operation was cancelled. " + innerException.Message);
                }
            }
        }
    }
}
