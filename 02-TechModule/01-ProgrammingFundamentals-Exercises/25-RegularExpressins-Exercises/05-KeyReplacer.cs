using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _05_KeyReplacer
{
    class Program
    {
        static void Main(string[] args)
        {
            string startEndPattern = @"^(?<start>[A-z]+)(\||<|\\).*(\||<|\\)(?<end>[A-z]+)$";

            string startEndString = Console.ReadLine();

            Match startEnd = Regex.Match(startEndString, startEndPattern);

            string start = startEnd.Groups["start"].Value;
            string end = startEnd.Groups["end"].Value;

            string wordPattern = start + @"(.*?)" + end;

            string text = Console.ReadLine();

            string[] words = Regex.Matches(text, wordPattern)
                .Cast<Match>()
                .Select(w => w.Groups[1].Value)
                .Where(w => w != "")
                .ToArray();

            if (words.Count() != 0)
            {
                Console.WriteLine(string.Join("", words));
            }
            else
            {
                Console.WriteLine("Empty result");
            }
        }
    }
}
