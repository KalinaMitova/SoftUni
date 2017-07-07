using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _04_MorseCodeUpgraded
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split('|');
            var output = new StringBuilder(input.Length);

            foreach (string codedLetter in input)
            {
                var zeros = codedLetter
                    .Where(n => n == '0')
                    .ToArray().Length;
                var ones = codedLetter
                    .Where(n => n == '1')
                    .ToArray().Length;

                var totalSum = zeros * 3 + ones * 5;

                var counter = 1;
                for (int i = 1; i < codedLetter.Length; i++)
                {
                    var prevNumber = char.GetNumericValue(codedLetter[i - 1]);
                    var currentNumber = char.GetNumericValue(codedLetter[i]);

                    if(currentNumber == prevNumber)
                    {
                        counter++;
                    }

                    if ((currentNumber != prevNumber || i == codedLetter.Length - 1) 
                        && counter != 1)
                    {
                        totalSum += counter;
                        counter = 1;
                    }
                }
                output.Append((char)totalSum);
            }

            Console.WriteLine(output.ToString());
        }
    }
}
