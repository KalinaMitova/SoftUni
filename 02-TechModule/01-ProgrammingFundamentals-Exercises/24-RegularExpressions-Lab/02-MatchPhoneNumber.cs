using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _02MatchPhoneNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            string regex = @"( |^)\+359( |-)2\2[\d]{3}\2[\d]{4}\b";

            string numbers = Console.ReadLine();

            MatchCollection matchedNumbers = Regex.Matches(numbers, regex);

            string[] phoneNumbers = matchedNumbers
                .Cast<Match>()
                .Select(p => p.Value.Trim())
                .ToArray();

            Console.WriteLine(string.Join(", ", phoneNumbers));
        }
    }
}
