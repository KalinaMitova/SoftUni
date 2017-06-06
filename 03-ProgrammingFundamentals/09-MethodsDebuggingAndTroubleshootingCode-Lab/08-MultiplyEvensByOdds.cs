using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08_MultiplyEvensByOdds
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int result = GetMultiplyOfEvensAndOdds(n);

            Console.WriteLine(result);
        }

        private static int GetMultiplyOfEvensAndOdds(int number)
        {
            int sumEvens = GetSumOfEvenDigits(number);
            int sumOdds = GetSumOfOddDigits(number);
            return sumEvens * sumOdds;
        }

        static int GetSumOfOddDigits(int n)
        {
            int currentNumber = Math.Abs(n);
            int sum = 0;
            
            while (currentNumber > 0)
            {
                int currentDigit = currentNumber % 10;
                if (currentDigit % 2 == 0)
                {
                    sum += currentDigit;
                }
                currentNumber /= 10;
            }

            return sum;
        }

        static int GetSumOfEvenDigits(int n)
        {
            int currentNumber = Math.Abs(n);
            int sum = 0;

            while (currentNumber > 0)
            {
                int currentDigit = currentNumber % 10;
                if (currentDigit % 2 != 0)
                {
                    sum += currentDigit;
                }
                currentNumber /= 10;
            }

            return sum;
        }
    }
}
