using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _05_MatchNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"(^|(?<=\s))-?\d+(\.\d+)?($|(?=\s))";

            string numbers = Console.ReadLine();

            MatchCollection matches = Regex.Matches(numbers, pattern);

            foreach (Match number in matches)
            {
                Console.Write(number.Value + " ");
            }

            Console.WriteLine();
        }
    }
}
