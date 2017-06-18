using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_SplitByWordCasing
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] separators = 
            {
                ',', ';', ':', '.',
                '!', '(', ')', '"',
                '\'', '\\', '/', '[',
                ']', ' '
            };

            List<string> words = Console.ReadLine().Split(separators).ToList();

            List<string> lowerCaseWords = new List<string>();
            List<string> upperCaseWords = new List<string>();
            List<string> mixedCaseWords = new List<string>();

            foreach (var word in words)
            {
                int length = word.Length;
                int lowerCases = 0;
                int upperCases = 0;

                if (length == 0)
                {
                    continue;
                }

                for (int i = 0; i < length; i++)
                {
                    if (char.IsLower(word[i]))
                    {
                        lowerCases++;
                    }
                    else if (char.IsUpper(word[i]))
                    {
                        upperCases++;
                    }
                }

                if (lowerCases == length)
                {
                    lowerCaseWords.Add(word);
                }
                else if (upperCases == length)
                {
                    upperCaseWords.Add(word);
                }
                else
                {
                    mixedCaseWords.Add(word);
                }
            }

            Console.WriteLine("Lower-case: " + String.Join(", ", lowerCaseWords));
            Console.WriteLine("Mixed-case: " + String.Join(", ", mixedCaseWords));
            Console.WriteLine("Upper-case: " + String.Join(", ", upperCaseWords));
        }
        
    }
}
