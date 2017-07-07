using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09_MelrahShake
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            string pattern = Console.ReadLine();

            int firstMatch = text.IndexOf(pattern); ;
            int lastMatch = text.LastIndexOf(pattern);

            while (pattern.Length > 0 && (firstMatch != -1 && lastMatch != -1 && firstMatch != lastMatch))
            {              
                Console.WriteLine("Shaked it.");
                text = text.Remove(lastMatch, pattern.Length);
                text = text.Remove(firstMatch, pattern.Length);
                pattern = pattern.Remove(pattern.Length / 2, 1);
                firstMatch = text.IndexOf(pattern);
                lastMatch = text.LastIndexOf(pattern);
            }

            Console.WriteLine("No shake.");
            Console.WriteLine(text);
        }
    }
}
