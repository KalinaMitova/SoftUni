using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_TripleSum
{
    class Program
    {
        static void Main(string[] args)
        {
            long[] numbers = Console.ReadLine().Split(' ')
                .Select(long.Parse).ToArray();

            bool match = false;

            for (int a = 0; a < numbers.Length; a++)
            {
                for (int b = a + 1; b < numbers.Length; b++)
                {
                    long sum = numbers[a] + numbers[b];
                    if (numbers.Contains(sum))
                    {
                        Console.WriteLine($"{numbers[a]} + {numbers[b]} == {sum}");
                        match = true;
                    }
                }
            }

            if (!match)
            {
                Console.WriteLine("No");
            }
        }
    }
}
