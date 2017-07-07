using System;

namespace _08_OddEvenSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int oddSum = 0;
            int evenSum = 0;

            for (int i = 1; i <= n; i++)
            {
                if (i % 2 == 0) evenSum += int.Parse(Console.ReadLine());
                else oddSum += int.Parse(Console.ReadLine());
            }
            
            if (oddSum == evenSum)
            {
                Console.WriteLine("Yes, sum = {0}", oddSum);
            }
            else
            {
                Console.WriteLine("No, diff = {0}", Math.Abs(oddSum - evenSum));
            }
        }
    }
}
