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
            int biggestCounter = 0;
            int startIndex = 0;

            for (int i = length - 1; i > 0; i--)
            {
                if (numbers[i] == numbers[i - 1])
                {
                    counter++;
                }
                else
                {
                    counter = 1;
                }

                if (biggestCounter <= counter)
                {
                    startIndex = i - 1;
                    biggestCounter = counter;
                }
            }

            for (int i = startIndex; i < startIndex + biggestCounter; i++)
            {
                Console.Write(numbers[i] + " ");
            }
            Console.WriteLine();
        }
    }
}
