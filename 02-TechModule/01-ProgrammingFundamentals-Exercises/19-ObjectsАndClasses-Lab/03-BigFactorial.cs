using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace _03_BigFactorial
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal n = decimal.Parse(Console.ReadLine());

            BigInteger factorial = 1;

            for (int i = 2; i <= n; i++) 
            {
                factorial *= i;
            }

            Console.WriteLine(factorial);
        }
    }
}
