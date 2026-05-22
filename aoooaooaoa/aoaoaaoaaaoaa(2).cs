using System;
using System.Threading.Tasks;

namespace epsteinfiles
{
    class Program
    {
        static bool IsPrime(int number)
        {
            if (number < 2)
                return false;

            for (int i = 2; i <= Math.Sqrt(number); i++)
            {
                if (number % i == 0)
                    return false;
            }

            return true;
        }

        static void PrintPrimes()
        {
            Console.WriteLine("Prime numbers from 0 to 1000:");

            for (int i = 0; i <= 1000; i++)
            {
                if (IsPrime(i))
                {
                    Console.Write(i + " ");
                }
            }

            Console.WriteLine();
        }

        static void Main()
        {
            Task task = Task.Run(PrintPrimes);

            task.Wait();

            Console.WriteLine("\nTask completed");
        }
    }
}
