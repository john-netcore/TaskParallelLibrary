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
            var task1 = new Task(() =>
            {
                System.Console.WriteLine("Task 1 is beginning.");
                Thread.Sleep(2000);
                System.Console.WriteLine("Task 1 has completed.");
            });

            //Starts to execute the task Action operations.
            task1.Start();

            //This code continues to execute parallel while the task Action is getting executed.
            Console.WriteLine("Press key to quit.");
            Console.ReadKey();
        }
    }
}
