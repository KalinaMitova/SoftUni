using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _03_MatchHexadecimalNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            string regex = @"\b(?:0x)?[0-9A-F]+\b";

            string text = Console.ReadLine();

            MatchCollection matchedNumbers = Regex.Matches(text, regex);

            string[] hexNumbers = matchedNumbers
                .Cast<Match>()
                .Select(h => h.Value.Trim())
                .ToArray();

            Console.WriteLine(string.Join(" ", hexNumbers));
        }
    }
}
