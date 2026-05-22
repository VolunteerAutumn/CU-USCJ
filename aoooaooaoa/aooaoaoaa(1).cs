using System;
using System.Threading.Tasks;

namespace epsteinfiles
{
    class Program
    {
        static void ShowDateTime()
        {
            Console.WriteLine($"Current date and time: {DateTime.Now}");
        }

        static void Main()
        {
            // 1. thru Start()
            Task task1 = new Task(ShowDateTime);
            task1.Start();

            // 2. thru Task.Factory.StartNew()
            Task task2 = Task.Factory.StartNew(ShowDateTime);

            // 3. thry Task.Run()
            Task task3 = Task.Run(ShowDateTime);

            Task.WaitAll(task1, task2, task3);

            Console.WriteLine("All tasks completed.");
        }
    }
}
