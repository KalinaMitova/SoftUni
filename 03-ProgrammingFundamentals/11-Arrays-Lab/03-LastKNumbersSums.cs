using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_LastKNumbersSums
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int k = int.Parse(Console.ReadLine());

            long[] numbers = new long[n];

            numbers[0] = 1;
            for (int i = 1; i < n; i++)
            {
                int start = 0;
                if (i >= k)
                {
                    start = i - k;
                }
                
                numbers[i] = Sum(numbers, start, i);
            }

            Console.WriteLine(String.Join(" ", numbers));
        }

        static long Sum(long[] numbers, int startIndex, int endIndex)
        {
            long sum = 0;
            for (int j = startIndex; j < endIndex; j++)
            {
                sum += numbers[j];
            }
            return sum;
        }
    }
}
