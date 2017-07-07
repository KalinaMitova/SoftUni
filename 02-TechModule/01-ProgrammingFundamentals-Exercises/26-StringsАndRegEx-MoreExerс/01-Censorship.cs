using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _01_Censorship
{
    class Program
    {
        static void Main(string[] args)
        {
            var word = Console.ReadLine();
            var text = Console.ReadLine();

            text = text.Replace(word, new string('*', word.Length));

            Console.WriteLine(text);
        }
    }
}
