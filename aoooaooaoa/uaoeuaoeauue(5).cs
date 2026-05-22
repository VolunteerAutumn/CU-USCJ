// this one was unironically a brainfuck
using System;
using System.Linq;
using System.Threading.Tasks;

namespace epsteinfiles
{
    class Program
    {
        static void Main()
        {
            int[] array = { 5, 3, 8, 3, 1, 5, 9, 2, 8, 7 };

            int[] uniqueArray = null;
            int[] sortedArray = null;

            Console.WriteLine("Original array:");
            Console.WriteLine(string.Join(" ", array));

            Task<int[]> removeDuplicatesTask = Task.Run(() =>
            {
                Console.WriteLine("\nRemoving duplicates...");
                return array.Distinct().ToArray();
            });

            Task<int[]> sortTask = removeDuplicatesTask.ContinueWith(previousTask =>
            {
                uniqueArray = previousTask.Result;

                Console.WriteLine("Array without duplicates:");
                Console.WriteLine(string.Join(" ", uniqueArray));

                Array.Sort(uniqueArray);

                Console.WriteLine("\nSorting array...");
                return uniqueArray;
            });

            Task searchTask = sortTask.ContinueWith(previousTask =>
            {
                sortedArray = previousTask.Result;

                Console.WriteLine("Sorted array:");
                Console.WriteLine(string.Join(" ", sortedArray));

                Console.Write("\nEnter number to search: ");
                int target = int.Parse(Console.ReadLine());

                int index = Array.BinarySearch(sortedArray, target);

                if (index >= 0)
                {
                    Console.WriteLine($"Number found at index {index}");
                }
                else
                {
                    Console.WriteLine("Number not found.");
                }
            });

            searchTask.Wait();

            Console.WriteLine("\nAll tasks completed.");
        }
    }
}
