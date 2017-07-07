using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08_MostFrequentNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int length = numbers.Length;
            int counter = 0;
            int bestCounter = 0;
            int mostFrequentNumber = 0;

            for (int i = length - 1; i >= 0; i--)
            {
                for (int j = length - 1; j >= 0; j--)
                {
                    if (numbers[i] == numbers[j])
                    {
                        counter++;
                    }
                    else
                    {
                        counter = 0;
                    }

                    if (bestCounter <= counter)
                    {
                        mostFrequentNumber = numbers[i];
                        bestCounter = counter;
                    }
                }                
            }

            Console.WriteLine(mostFrequentNumber);
        }
    }
}
