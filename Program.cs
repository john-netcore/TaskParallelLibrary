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
            var task1 = Task.Factory.StartNew(() => DoSomeVeryImportantWork(1, 2000))
                                    .ContinueWith((prevTask) => DoSomeOtherVeryImportantWork(1, 1000));
            var task2 = Task.Factory.StartNew(() => DoSomeVeryImportantWork(2, 3000));
            var task3 = Task.Factory.StartNew(() => DoSomeVeryImportantWork(3, 1000));

            //Blocks execution until all the tasks have finished their operations.
            Task.WaitAll(task1, task2, task3);

            Console.WriteLine("Press key to quit.");
            Console.ReadKey();
        }

        static void DoSomeVeryImportantWork(int id, int sleepTime)
        {
            System.Console.WriteLine("Task {0} is beginning.", id);
            Thread.Sleep(sleepTime);
            System.Console.WriteLine("Task {0} has completed.", id);
        }

        static void DoSomeOtherVeryImportantWork(int id, int sleepTime)
        {
            System.Console.WriteLine("Task {0} is beginning other work.", id);
            Thread.Sleep(sleepTime);
            System.Console.WriteLine("Task {0} has completed other work.", id);
        }
    }
}
