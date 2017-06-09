using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_SieveOfEratosthenes
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            bool[] primes = new bool[n + 1];

            for (int i = 0; i <= n; i++)
            {
                primes[i] = true;
            }

            primes[0] = primes[1] = false;

            for (int i = 0; i <= n; i++)
            {
                if (primes[i])
                {
                    Console.Write(i + " ");

                    for (int p = 2 * i; p <= n; p += i)
                    {
                        primes[p] = false;
                    }
                }                
            }

            Console.WriteLine();
        }
    }
}
