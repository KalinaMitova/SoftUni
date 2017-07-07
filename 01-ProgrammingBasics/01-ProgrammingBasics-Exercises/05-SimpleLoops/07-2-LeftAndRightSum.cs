using System;

namespace _07_0_LeftAndRightSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int firstSum = 0;
            int secondSum = 0;

            for (int i = 0; i < n; i++)
                firstSum += int.Parse(Console.ReadLine());
            
            for (int j = 0; j < n; j++)
                secondSum += int.Parse(Console.ReadLine());
            
            if (firstSum == secondSum) Console.WriteLine("Yes, sum = {0}", firstSum);
            else Console.WriteLine("No, diff = {0}", Math.Abs(firstSum - secondSum));
        }
    }
}
