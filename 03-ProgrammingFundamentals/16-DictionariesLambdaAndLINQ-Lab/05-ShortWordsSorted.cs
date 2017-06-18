using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05_ShortWordsSorted
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] separators =
            {
                '.', ',', ':', ';',
                '(', ')', '[', ']',
                '"', '\'', '\\', '/',
                '!', '?', ' '
            };

            var words = Console.ReadLine().ToLower().Split(separators).ToList();

            var shortWords = words.Where(p => p != "" && p.Length < 5);

            var orderedWords = shortWords.OrderBy(p => p).Distinct();

            Console.WriteLine(string.Join(", ", orderedWords));
        }
    }
}
