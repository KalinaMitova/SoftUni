using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_CharacterMultiplier
{
    class Program
    {
        static void Main(string[] args)
        {
            var tokens = Console.ReadLine().Split();
            var str1 = tokens[0];
            var str2 = tokens[1];

            var totalSum = MultiplyCharacters(str1, str2);

            Console.WriteLine(totalSum);
        }

        private static decimal MultiplyCharacters(string str1, string str2)
        {
            decimal totalSum = 0;

            int length = Math.Max(str1.Length, str2.Length);

            for (int i = 0; i < length; i++)
            {
                if (i > str1.Length - 1)
                {
                    totalSum += str2[i];
                }
                else if (i > str2.Length - 1)
                {
                    totalSum += str1[i];
                }
                else
                {
                    totalSum += str1[i] * str2[i];
                }
            }

            return totalSum;
        }
    }
}
