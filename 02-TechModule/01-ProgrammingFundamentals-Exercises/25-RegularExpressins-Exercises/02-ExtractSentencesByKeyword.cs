using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _02_ExtractSentencesByKeyword
{
    class Program
    {
        static void Main(string[] args)
        {
            string wordToSearch = Console.ReadLine();
            string pattern = $@"(\b|\s)(?<sentence>[^.?!]*\b{wordToSearch}\b[^.?!]*)(\.|\?|\!)";

            string text = Console.ReadLine();

            MatchCollection matches = Regex.Matches(text, pattern);

            foreach (Match sentence in matches)
            {
                Console.WriteLine(sentence.Groups["sentence"]);
            }
        }
    }
}
