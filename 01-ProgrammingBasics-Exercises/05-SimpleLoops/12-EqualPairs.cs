using System;

namespace _12_EqualPairs
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int prevSum = 0;
            int diff = 0;
            int maxDiff = int.MinValue;

            for (int i = 0; i < n; i++)
            {
                int firstNum = int.Parse(Console.ReadLine());
                int secondNum = int.Parse(Console.ReadLine());
                int sum = firstNum + secondNum;

                if (i == 0)
                {
                    prevSum = sum;
                }
                else
                {
                    diff = Math.Max(prevSum, sum) - Math.Min(prevSum, sum);
                    prevSum = sum;
                }

                if (diff > maxDiff)
                {
                    maxDiff = diff;
                }
            }

            if (maxDiff == 0)
            {
                Console.WriteLine("Yes, value={0}", prevSum);
            }
            else
            {
                Console.WriteLine("No, maxdiff={0}", maxDiff);
            }
        }
    }
}
