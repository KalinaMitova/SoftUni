using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _08_UseYourChainsBuddy
{
    class Program
    {
        static void Main(string[] args)
        {
            string extractParagraphsPattern = @"<p>(?<message>.+?)<\/p>";

            string text = Console.ReadLine();

            var paragraphs = Regex.Matches(text, extractParagraphsPattern)
                .Cast<Match>()
                .Select(p => p.Groups["message"].Value)
                .Select(p => Regex.Replace(p, @"[^a-z0-9]", " "))
                .Select(p => Regex.Replace(p, @" +", " "))
                .Select(p => new string(p.ToCharArray()
                    .Select(c => c >= 'a' && c <= 'm' ? (char)(c + 13) :
                        c >= 'n' && c <= 'z' ? (char)(c - 13) : c
                        ).ToArray()))
                .ToArray();

            Console.WriteLine(string.Join("", paragraphs));            
        }
    }
}
