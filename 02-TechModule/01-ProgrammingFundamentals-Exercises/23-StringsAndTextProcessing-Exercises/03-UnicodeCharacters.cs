using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_UnicodeCharacters
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();

            foreach (var character in input)
            {
                var charToNumber = Convert.ToInt32(character);
                Console.Write($"\\u{charToNumber:x4}");
            }
            Console.WriteLine();
        }
    }
}
