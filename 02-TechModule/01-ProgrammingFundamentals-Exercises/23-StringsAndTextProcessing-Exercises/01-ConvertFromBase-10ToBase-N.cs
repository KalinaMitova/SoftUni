using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace _01_ConvertFromBase_10ToBase_N
{
    class Program
    {
        static void Main(string[] args)
        {
            var tokens = Console.ReadLine().Split().Select(BigInteger.Parse).ToArray();
            var toBase = tokens[0];
            var number = tokens[1];
            
            var converted = "";

            while (number > 0)
            {
                converted += number % toBase;
                number /= toBase;
            }

            var reverseConvertedNumber = new string(converted.Reverse().ToArray());

            Console.WriteLine(reverseConvertedNumber);
        }
    }
}
