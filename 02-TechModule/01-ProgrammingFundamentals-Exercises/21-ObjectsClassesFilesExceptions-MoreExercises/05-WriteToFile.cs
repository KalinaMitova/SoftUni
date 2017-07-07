using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_PunctuationFinder
{
    class Program
    {
        static void Main(string[] args)
        {
            var text = File.ReadAllText("sample_text.txt");

            var chars = new char[] { '.', ',', '!', '?', ':' };

            var removedChars = string.Join("", text.Split(chars));

            File.WriteAllText("output.txt", removedChars);
        }
    }
}
