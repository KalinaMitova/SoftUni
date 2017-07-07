namespace _09_RefactorSpecialNumbers
{
    using System;

    static class RefactorSpecialNumbers
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            for (int num = 1; num <= n; num++)
            {
                int sum = 0;
                int currentNum = num;
                while (currentNum > 0)
                {
                    sum += currentNum % 10;
                    currentNum /= 10;
                }
                bool isEqual = (sum == 5) || (sum == 7) || (sum == 11);
                Console.WriteLine($"{num} -> {isEqual}");
            }

        }
    }
}
