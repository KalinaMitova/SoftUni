using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10_PairsByDifference
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int diff = int.Parse(Console.ReadLine());

            int length = numbers.Length;
            int counter = 0;

            for (int i = 0; i < length; i++)
            {
                for (int j = i; j < length; j++)
                {
                    int currentDiff = Math.Abs(numbers[i] - numbers[j]);
                    if (currentDiff == diff)
                    {
                        counter++;
                    }
                }
            }

            Console.WriteLine(counter);
        }
    }
}
