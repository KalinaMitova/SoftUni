using System;
using System.Numerics;

namespace _13_Factorial
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            BigInteger factorial = GetFactorial(n);

            int trailingZeroes = countTrailingZeroes(factorial);

            Console.WriteLine(trailingZeroes);
        }

        private static int countTrailingZeroes(BigInteger factorial)
        {
            int counter = 0;

            while (factorial > 0)
            {
                if (factorial % 10 == 0)
                {
                    counter++;
                }
                else
                {
                    return counter;
                }
                factorial /= 10;
            }
            return counter;
        }

        static BigInteger GetFactorial(int n)
        {
            BigInteger factorial = 1;
            for (int i = 1; i <= n; i++)
            {
                factorial *= i;
            }
            return factorial;
        }
    }
}
