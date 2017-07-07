using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _06_ValidUsernames
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"(?<=\(|\)|\\|\/| |^|\b)(?<user>[A-Za-z][A-Za-z0-9_]{2,24})(?=\(|\)|\\|\/| |\b|$)";
            
            string text = Console.ReadLine();

            string[] usernames = Regex.Matches(text, pattern)
                .Cast<Match>()
                .Select(u => u.Groups["user"].Value)
                .ToArray();

            string prevUsername = usernames[0];
            int bestLength = 0;
            int bestIndex = 0;

            for (int i = 1; i < usernames.Length; i++)
            {
                string currentUsername = usernames[i];

                if (bestLength < currentUsername.Length + prevUsername.Length)
                {
                    bestLength = currentUsername.Length + prevUsername.Length;
                    bestIndex = i;
                }

                prevUsername = currentUsername;
            }

            Console.WriteLine(usernames[bestIndex - 1]);
            Console.WriteLine(usernames[bestIndex]);
        }
    }
}
