using System;
using System.Threading;
using System.Threading.Tasks;

namespace TaskParallelLibrary
{
    class Program
    {
        static void Main(string[] args)
        {
            //Declaration of tasks. The tasks don't do anything until they get started.
            var task1 = new Task(() => DoSomeVeryImportantWork(1, 2000));
            var task2 = new Task(() => DoSomeVeryImportantWork(2, 3000));
            var task3 = new Task(() => DoSomeVeryImportantWork(3, 1000));

            //Starts to execute the task operations.
            task1.Start();
            task2.Start();
            task3.Start();

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
