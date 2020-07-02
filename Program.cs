using System;
using System.Threading;
using System.Threading.Tasks;

namespace TaskParallelLibrary
{
    class Program
    {
        static void Main(string[] args)
        {
            //Declaration of task one. The task does not do anything until it gets started.
            var task1 = new Task(() => DoSomeVeryImportantWork(1, 2000));

            //Starts to execute the task operations.
            task1.Start();

            //This code continues to execute in parallel with the task operations.
            Console.WriteLine("Press key to quit.");
            Console.ReadKey();
        }

        static void DoSomeVeryImportantWork(int id, int sleepTime)
        {
            System.Console.WriteLine("Task {0} is beginning.", id);
            Thread.Sleep(sleepTime);
            System.Console.WriteLine("Task {0} has completed.", id);
        }
    }
}
