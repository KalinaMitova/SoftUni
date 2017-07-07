using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _08_Mines
{
    class Program
    {
        static void Main(string[] args)
        {
            string minePattern = @"<(?<mine>.{2})>";

            string path = Console.ReadLine();

            MatchCollection mines = Regex.Matches(path, minePattern);

            foreach (Match mine in mines)
            {
                char firstChar = mine.Groups["mine"].Value[0];
                char secondChar = mine.Groups["mine"].Value[1];

                int blastRadius = Math.Abs(firstChar - secondChar);
                
                var pattern = $@".{{0,{blastRadius}}}<{firstChar}{secondChar}>.{{0,{blastRadius}}}";
                path = Regex.Replace(path, pattern, m => new string('_', m.Length));
            }

            Console.WriteLine(path);
        }
    }
}
