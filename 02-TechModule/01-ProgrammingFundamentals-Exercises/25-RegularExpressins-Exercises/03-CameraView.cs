using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _03_CameraView
{
    class Program
    {
        public static object MarchCollection { get; private set; }

        static void Main(string[] args)
        {
            int[] tokens = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int m = tokens[0];
            int n = tokens[1];

            string pattern = @"(?<=\|<)[^\|<]*";

            string text = Console.ReadLine();

            MatchCollection matches = Regex.Matches(text, pattern);

            var words = matches
                .Cast<Match>()
                .Select(w => new string(w.Value
                    .Skip(m)
                    .Take(n)
                    .ToArray()))
                .ToArray();

            Console.WriteLine(string.Join(", ", words));
        }
    }
}
