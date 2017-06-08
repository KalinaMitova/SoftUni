using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07_SumArrays
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] firstArr = Console.ReadLine().Split(' ')
                .Select(int.Parse).ToArray();
            int[] secondArr = Console.ReadLine().Split(' ')
                .Select(int.Parse).ToArray();
            
            int len1 = firstArr.Length;
            int len2 = secondArr.Length;

            int maxLength = Math.Max(len1, len2);
            int[] sum = new int[maxLength];

            for (int i = 0; i < maxLength; i++)
            {
                sum[i] = firstArr[i % len1] + secondArr[i % len2];
            }

            Console.WriteLine(string.Join(" ", sum));
        }
    }
}
