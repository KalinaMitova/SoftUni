using System;

namespace _10_2_CheckPrime
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            bool isPrime = true;
            string divisor = "";

            if (n < 2)
            {
                isPrime = false;
            }
            else
            {
                double maxN = (int)Math.Sqrt(n) + 1;
                for (int i = 2; i < maxN; i++)
                {
                    if (n % i == 0)
                    {
                        isPrime = false;
                        divisor += i + ", ";
                    }
                }
            }

            if (isPrime)
            {
                Console.WriteLine("The number is prime! It is divisible only by 1 and {0}.", n);
            }
            else
            {
                Console.WriteLine("The number is not prime! It is divisible by {0}.", divisor.Substring(0, divisor.Length - 2));
            }
        }
    }
}
