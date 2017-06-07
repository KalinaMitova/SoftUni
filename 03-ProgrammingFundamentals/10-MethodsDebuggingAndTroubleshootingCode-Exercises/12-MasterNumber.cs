using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _12_MasterNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 1; i <= n; i++)
            {
                int currentNumber = i;

                if (IsPalindrome(currentNumber) && SumOfDigits(currentNumber) && ContainsEvenDigit(currentNumber))
                {
                    Console.WriteLine(currentNumber);
                }
            }
        }

        static bool IsPalindrome(int number)
        {
            string numberToString = number.ToString();
            int length = numberToString.Length;

            if (length == 1)
            {
                return true;
            }

            for (int i = 0; i < length / 2; i++)
            {
                if (numberToString[i] != numberToString[length - i - 1])
                {
                    return false;
                }
            }
            return true;
        }

        static bool SumOfDigits(int number)
        {
            int sum = 0;

            while (number > 0)
            {
                sum += number % 10;
                number /= 10;
            }

            if (sum % 7 == 0)
            {
                return true;
            }

            return false;
        }

        static bool ContainsEvenDigit(int number)
        {
            while (number > 0)
            {
                int cuurentDigit = number % 10;
                if (cuurentDigit % 2 == 0)
                {
                    return true;
                }
                number /= 10;
            }

            return false;
        }
    }
}
