using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace TaskParallelLibrary
{
    class Program
    {
        static void Main(string[] args)
        {
            var source = new CancellationTokenSource();

            try
            {
                Task.Factory.StartNew(() => DoSomeVeryImportantWork(1, 2000, source.Token))
                                .ContinueWith((prevTask) => DoSomeOtherVeryImportantWork(1, 1500, source.Token));
            }
            catch (Exception e)
            {
                System.Console.WriteLine(e.GetType());
            }

            Thread.Sleep(500);
            source.Cancel();

            Console.WriteLine("Press key to quit.");
            Console.ReadKey();
        }

        static void DoSomeVeryImportantWork(int id, int sleepTime, CancellationToken token)
        {
            if (token.IsCancellationRequested)
            {
                System.Console.WriteLine("Cancellation requested.");
                token.ThrowIfCancellationRequested();
            }
            System.Console.WriteLine("Task {0} is beginning.", id);
            Thread.Sleep(sleepTime);
            System.Console.WriteLine("Task {0} has completed.", id);
        }

        static void DoSomeOtherVeryImportantWork(int id, int sleepTime, CancellationToken token)
        {
            if (token.IsCancellationRequested)
            {
                System.Console.WriteLine("Cancellation requested.");
                token.ThrowIfCancellationRequested();
            }
            System.Console.WriteLine("Task {0} is beginning other work.", id);
            Thread.Sleep(sleepTime);
            System.Console.WriteLine("Task {0} has completed other work.", id);
        }
    }
}
