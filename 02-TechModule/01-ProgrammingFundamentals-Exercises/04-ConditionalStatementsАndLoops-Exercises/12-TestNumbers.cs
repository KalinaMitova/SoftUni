using System;

namespace _12_TestNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int m = int.Parse(Console.ReadLine());
            int maxSumBoundary = int.Parse(Console.ReadLine());
            int totalSum = 0;
            int counter = 0;

            for (int i = n; i >= 1; i--)
            {
                for (int j = 1; j <= m; j++)
                {
                    totalSum += (i * j) * 3;
                    counter++;

                    if (totalSum >= maxSumBoundary)
                    {
                        Console.WriteLine($"{counter} combinations");
                        Console.WriteLine($"Sum: {totalSum} >= {maxSumBoundary}");
                        return;
                    }
                }
            }

            Console.WriteLine($"{counter} combinations");
            Console.WriteLine($"Sum: {totalSum}");
        }
    }
}
