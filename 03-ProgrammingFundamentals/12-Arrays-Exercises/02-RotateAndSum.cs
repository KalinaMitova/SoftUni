using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_RotateAndSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int k = int.Parse(Console.ReadLine());

            int length = numbers.Length;
            int[] sum = new int[length];

            for (int i = 0; i < k; i++)
            {
                int lastNumber = numbers[length - 1];
                for (int j = 1; j < length; j++)
                {
                    numbers[length - j] = numbers[length - j - 1];
                    sum[length - j] += numbers[length - j - 1];
                }
                numbers[0] = lastNumber;
                sum[0] += lastNumber;
            }

            Console.WriteLine(String.Join(" ", sum));
        }
    }
}
