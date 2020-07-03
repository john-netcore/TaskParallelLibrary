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
            var workToDo = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20 };

            System.Console.WriteLine("Running list content in parallel:");

            //Executing Actions in parallel, Parallel blocks the code until it is done with all the operations.
            Parallel.ForEach(workToDo, i => System.Console.WriteLine(i));

            System.Console.WriteLine("Running numbers between 1 and 100 in parallel:");

            //Runs an action for all the numbers between 1 and 100 in parallel.
            Parallel.For(1, 100, i => System.Console.Write("{0} ", i));

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
