using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_RandomizeWords
{
    class Program
    {
        static void Main(string[] args)
        {
            var words = Console.ReadLine().Split();

            var length = words.Length;
            var random = new Random();

            for (int pos1 = 0; pos1 < length; pos1++)
            {
                var pos2 = random.Next(0, length);

                var oldWord = words[pos2];
                if (pos1 != pos2)
                {
                    words[pos2] = words[pos1];
                    words[pos1] = oldWord;
                }
            }

            Console.WriteLine(string.Join("\r\n", words));
        }
    }
}
