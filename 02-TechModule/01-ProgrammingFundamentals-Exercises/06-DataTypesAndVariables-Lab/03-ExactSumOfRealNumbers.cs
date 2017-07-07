namespace _3_ExactSumOfRealNumbers
{
    using System;

    static class SumOfRealNumbers
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            decimal exactSum = 0m;
            for (int i = 0; i < n; i++)
            {
                exactSum += decimal.Parse(Console.ReadLine());
            }
            Console.WriteLine(exactSum);
        }
    }
}
