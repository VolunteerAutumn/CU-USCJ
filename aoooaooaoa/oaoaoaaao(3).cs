using System;
using System.Collections.Generic;
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

        static List<int> GeneratePrimes(int start, int end)
        {
            List<int> primes = new List<int>();

            for (int i = start; i <= end; i++)
            {
                if (IsPrime(i))
                {
                    primes.Add(i);
                }
            }

            return primes;
        }

        static void Main()
        {
            Console.Write("Enter start: ");
            int start = int.Parse(Console.ReadLine());

            Console.Write("Enter end: ");
            int end = int.Parse(Console.ReadLine());

            Task<List<int>> task = Task.Run(() =>
            {
                return GeneratePrimes(start, end);
            });

            task.Wait();

            List<int> result = task.Result;

            Console.WriteLine("\nPrime numbers:");

            foreach (int num in result)
            {
                Console.Write(num + " ");
            }

            Console.WriteLine($"\n\nCount of prime numbers: {result.Count}");
        }
    }
}
