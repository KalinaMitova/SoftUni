using System;

namespace _06_Digits
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            int firstDigit = num / 100;
            int secondDigit = (num / 10) % 10;
            int thirdDigit = num % 10;

            int n = firstDigit + secondDigit;
            int m = firstDigit + thirdDigit;

            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < m; col++)
                {
                    if (num % 5 == 0)
                    {
                        num -= firstDigit;
                    }
                    else if (num % 3 == 0)
                    {
                        num -= secondDigit;
                    }
                    else
                    {
                        num += thirdDigit;
                    }
                    Console.Write(num + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
