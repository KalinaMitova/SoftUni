using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_FoldAndSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int leftRightLength = numbers.Length / 4;
            int[] left = new int[leftRightLength];
            int[] rigth = new int[leftRightLength];
            int[] sum = new int[numbers.Length / 2];

            for (int i = 0; i < leftRightLength; i++)
            {
                left[leftRightLength - i - 1] = numbers[i];
                rigth[i] = numbers[numbers.Length - i - 1];
            }

            for (int i = 0; i < sum.Length; i++)
            {
                sum[i] = numbers[i + leftRightLength];
            }
            
            for (int i = 0; i < leftRightLength; i++)
            {
                sum[i] += left[i];
                sum[i + leftRightLength] += rigth[i];
            }

            Console.WriteLine(String.Join(" ", sum));
        }
    }
}
