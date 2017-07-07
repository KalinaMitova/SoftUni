using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _01_ExtractEmails
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"(^|\s)((?<user>[A-Za-z\d]+[._-]?[A-Za-z\d]+)@(?<host>[A-Za-z\d]+(-[A-Za-z\d]+)?(\.[a-z]{2,})+))\b";

            string text = Console.ReadLine();

            MatchCollection matches = Regex.Matches(text, pattern);

            foreach (Match email in matches)
            {
                Console.WriteLine(email.Groups[2]);
            }
        }
    }
}
