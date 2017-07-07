using System;

namespace _10_HalfSumElement
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int maxNum = int.Parse(Console.ReadLine()); ;
            int sum = maxNum;

            for (int i = 1; i < n; i++)
            {
                int currentNum = int.Parse(Console.ReadLine());
                sum += currentNum;
                if (maxNum < currentNum)
                {
                    maxNum = currentNum;
                }
            }

            sum -= maxNum;

            if (sum == maxNum)
            {
                Console.WriteLine("Yes");
                Console.WriteLine("Sum = {0}", sum);
            }
            else
            {
                Console.WriteLine("No");
                Console.WriteLine("Diff = {0}", Math.Abs(maxNum - sum));
            }
        }
    }
}
