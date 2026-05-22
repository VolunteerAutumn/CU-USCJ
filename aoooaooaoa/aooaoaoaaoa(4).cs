using System;
using System.Linq;
using System.Threading.Tasks;

namespace epsteinfiles
{
    class Program
    {
        static void Main()
        {
            int[] array = { 5, 12, 7, 3, 9, 15, 1, 20 };

            int min = 0;
            int max = 0;
            int sum = 0;
            double average = 0;

            Task[] tasks = new Task[4];

            tasks[0] = Task.Run(() =>
            {
                min = array.Min();
                Console.WriteLine($"Minimum: {min}");
            });

            tasks[1] = Task.Run(() =>
            {
                max = array.Max();
                Console.WriteLine($"Maximum: {max}");
            });

            tasks[2] = Task.Run(() =>
            {
                sum = array.Sum();
                Console.WriteLine($"Sum: {sum}");
            });

            tasks[3] = Task.Run(() =>
            {
                average = array.Average();
                Console.WriteLine($"Average: {average}");
            });

            Task.WaitAll(tasks);

            Console.WriteLine("\nAll calculations completed.");
        }
    }
}

// ez gg no re lmfao
