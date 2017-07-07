using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _01_MatchFullName
{
    class Program
    {
        static void Main(string[] args)
        {
            string regex = @"\b[A-Z]{1}[a-z]+[ ]{1}[A-Z]{1}[a-z]+\b";

            string names = Console.ReadLine();

            MatchCollection matchedNames = Regex.Matches(names, regex);

            foreach (Match name in matchedNames)
            {
                Console.Write(name.Value + " ");
            }
            Console.WriteLine();
        }
    }
}