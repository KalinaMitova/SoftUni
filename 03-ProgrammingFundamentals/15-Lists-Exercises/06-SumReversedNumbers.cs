using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06_SumReversedNumbers
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

            for (int i = 0; i < numbers.Count; i++)
            {
                int currentNumbers = numbers[i];
                int reversed = 0;

                while (currentNumbers > 0)
                {
                    reversed = reversed * 10 + currentNumbers % 10;
                    currentNumbers /= 10;
                }

                numbers[i] = reversed;
            }

            Console.WriteLine(numbers.Sum());
        }
    }
}
