namespace _02_DiagonalDifference
{
    using System;

    public class DiagonalDifference
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            
            int leftSum = 0;
            int rightSum = 0;

            for (int i = 0; i < n; i++)
            {
                string[] numbers = Console.ReadLine().Split();

                leftSum += int.Parse(numbers[i]);
                rightSum += int.Parse(numbers[n - i - 1]);
            }

            Console.WriteLine(Math.Abs(leftSum - rightSum));
        }
    }
}
