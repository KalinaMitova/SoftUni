using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_ArrayStatistics
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int minNumber = numbers.Min();
            int maxNumber = numbers.Max();
            int sum = numbers.Sum();
            double average = numbers.Average();

            Console.WriteLine("Min = {0}", minNumber);
            Console.WriteLine("Max = {0}", maxNumber);
            Console.WriteLine("Sum = {0}", sum);
            Console.WriteLine("Average = {0}", average);
        }
    }
}