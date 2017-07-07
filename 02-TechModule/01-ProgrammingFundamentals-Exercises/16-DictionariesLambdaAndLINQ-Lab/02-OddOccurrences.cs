using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_OddOccurrences
{
    class Program
    {
        static void Main(string[] args)
        {
            var words = Console.ReadLine().ToLower().Split().ToArray();
            var dict = new Dictionary<string, int>();

            foreach (var w in words)
            {
                if (dict.ContainsKey(w))
                {
                    dict[w]++;
                }
                else
                {
                    dict.Add(w, 1);
                }
            }

            var output = new List<string>();

            foreach (var word in dict)
            {
                if (word.Value % 2 == 1)
                {
                    output.Add(word.Key);
                }
            }

            Console.WriteLine(string.Join(", ", output));
        }
    }
}
