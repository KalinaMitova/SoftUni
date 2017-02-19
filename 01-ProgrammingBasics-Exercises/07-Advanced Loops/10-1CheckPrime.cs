using System;

namespace _10_1_CheckPrime
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            bool isPrime = true;

            if (n < 2)
            {
                isPrime = false;
            }
            else
            {
                int maxN = (int)Math.Sqrt(n) + 1;
                for (int i = 2; i < maxN; i++)
                {
                    if (n % i == 0)
                    {
                        isPrime = false;
                        break;
                    }
                }
            }

            if (isPrime)
            {
                Console.WriteLine("prime");
            }
            else
            {
                Console.WriteLine("not prime");
            }
        }
    }
}
