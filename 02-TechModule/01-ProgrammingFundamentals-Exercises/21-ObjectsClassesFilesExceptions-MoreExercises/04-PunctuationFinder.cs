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

            var findedPunctuations = text.Where(c => c == '.' || c == ',' || c == '!' || c == '?' || c == ':');

            File.WriteAllText("output.txt", string.Join(", ", findedPunctuations));
        }
    }
}
