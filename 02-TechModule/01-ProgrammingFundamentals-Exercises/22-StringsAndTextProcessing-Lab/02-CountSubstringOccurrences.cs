using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_CountSubstringOccurrences
{
    class Program
    {
        static void Main(string[] args)
        {
            var text = Console.ReadLine().ToLower();
            var wordToSearch = Console.ReadLine().ToLower();

            var counter = 0;
            var startIndex = 0;
            var index = text.IndexOf(wordToSearch, startIndex);

            while (index >= 0)
            {
                startIndex = index + 1;
                counter++;
                index = text.IndexOf(wordToSearch, startIndex);
            }

            Console.WriteLine(counter);
        }
    }
}
