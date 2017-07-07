using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace _02_ConvertFromBase_NToBase_10
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] tokens = Console.ReadLine().Split();
            int fromBase = int.Parse(tokens[0]);
            BigInteger number = BigInteger.Parse(tokens[1]);
            
            BigInteger converted = 0;
            int index = 0;

            while (number > 0)
            {
                BigInteger pow = 1;

                for (int i = 0; i < index; i++)
                {
                    pow *= fromBase;
                }

                converted += (number % 10) * pow;
                number /= 10;
                index++;
            }
            
            Console.WriteLine(converted);
        }
    }
}
