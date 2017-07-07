using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_MaxSequenceOfEqualElements
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers =
                Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            // 3 4 4 5 5 5 2 2

            int length = numbers.Count;
            int counter = 0;

            int bestCount = 0;
            int bestStart = 0;

            for (int i = 1; i < length; i++)
            {
                if (numbers[i - 1] == numbers[i])
                {
                    counter++;
                }
                else
                {
                    counter = 0;
                }

                if (counter > bestCount)
                {
                    bestCount = counter;
                    bestStart = i - counter;
                }
            }

            for (int i = bestStart; i <= bestStart + bestCount; i++)
            {
                Console.Write(numbers[i]);
                if (i != bestStart + bestCount)
                {
                    Console.Write(" ");
                }
            }
            Console.WriteLine();
        }
    }
}
