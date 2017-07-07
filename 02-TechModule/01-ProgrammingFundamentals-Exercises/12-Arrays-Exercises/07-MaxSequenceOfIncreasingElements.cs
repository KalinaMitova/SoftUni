using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06_MaxSequenceOfEqualElements
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int length = numbers.Length;
            int counter = 1;
            int bestCounter = 0;
            int bestStart = 0;

            for (int i = length - 1; i > 0; i--)
            {
                if (numbers[i] > numbers[i - 1])
                {
                    counter++;
                }
                else
                {
                    counter = 1;
                }

                if (bestCounter <= counter)
                {
                    bestStart = i - 1;
                    bestCounter = counter;
                }
            }

            for (int i = bestStart; i < bestStart + bestCounter; i++)
            {
                Console.Write(numbers[i] + " ");
            }
            Console.WriteLine();
        }
    }
}
