using System;
using System.Threading;
using System.Threading.Tasks;

namespace TaskParallelLibrary
{
    class Program
    {
        static void Main(string[] args)
        {
            //Declaration and initialization of tasks.
            var task1 = Task.Factory.StartNew(() => DoSomeVeryImportantWork(1, 2000));
            var task2 = Task.Factory.StartNew(() => DoSomeVeryImportantWork(2, 3000));
            var task3 = Task.Factory.StartNew(() => DoSomeVeryImportantWork(3, 1000));

            //This code continues to execute in parallel with the tasks operations.
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
