using System;

namespace _07_1_LeftAndRightSum
{
    class Program
    {
        static int Summator(int sum, int n)
        {
            for (int i = 0; i < n; i++)
                sum += int.Parse(Console.ReadLine());
            return sum;
        }

        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int firstSum = 0;
            int secondSum = 0;

            firstSum = Summator(firstSum, n);
            secondSum = Summator(secondSum, n);

            if (firstSum == secondSum) Console.WriteLine("Yes, sum = {0}", firstSum);
            else Console.WriteLine("No, diff = {0}", Math.Abs(firstSum - secondSum));
        }
    }
}
