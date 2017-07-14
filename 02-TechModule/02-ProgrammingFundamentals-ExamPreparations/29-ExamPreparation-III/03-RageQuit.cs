using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _03_RageQuit
{
    class Program
    {
        static void Main(string[] args)
        {
            List<char> allsymbols = new List<char>();
            var pattern = @"(?<symbols>[^\d]+)(?<count>\d+)";

            var sequence = Console.ReadLine();

            MatchCollection matches = Regex.Matches(sequence, pattern);

            StringBuilder output = new StringBuilder();

            foreach (Match subsequence in matches)
            {
                var symbols = subsequence.Groups["symbols"].Value;
                var count = int.Parse(subsequence.Groups["count"].Value);

                if (count != 0 && count <= 20)
                {
                    string symbolsToUpper = symbols.ToUpper();

                    allsymbols.AddRange(symbolsToUpper.Distinct());

                    output.Append(string.Concat(Enumerable.Repeat(symbolsToUpper, count).ToArray()));
                }
            }

            var allUniqueSymbols = allsymbols.Distinct().ToList();

            Console.WriteLine($"Unique symbols used: {allUniqueSymbols.Count}");
            Console.WriteLine(output.ToString());
        }
    }
}
