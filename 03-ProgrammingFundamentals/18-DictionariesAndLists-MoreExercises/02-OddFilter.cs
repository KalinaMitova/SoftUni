using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_OddFilter
{
    class Program
    {
        static void Main(string[] args)
        {
            //1 2 3 4 5 6 7 8 9 10

            var numbers = Console.ReadLine().Split().Select(int.Parse).ToList();
                        
            for (int i = 0; i < numbers.Count; i++)
            {
                if (numbers[i] % 2 == 1)
                {
                    numbers.RemoveAt(i);
                    i--;                }
            }

            var average = numbers.Average();

            for (int i = 0; i < numbers.Count; i++)
            {
                if (numbers[i] > average)
                {
                    numbers[i]++;
                }
                else
                {
                    numbers[i]--;
                }
            }

            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
