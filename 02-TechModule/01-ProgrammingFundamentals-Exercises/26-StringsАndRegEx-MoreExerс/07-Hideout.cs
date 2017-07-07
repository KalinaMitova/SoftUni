using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _07_Hideout
{
    class Program
    {
        static void Main(string[] args)
        {
            // @"@{5,}";
            string map = Console.ReadLine();

            while (true)
            {
                string[] tokens = Console.ReadLine().Split();

                char searchedChar = char.Parse(tokens[0]);
                int minimumCount = int.Parse(tokens[1]);

                string pattern = $@"\{searchedChar}{{{minimumCount},}}";

                Match hideout = Regex.Match(map, pattern);

                if (hideout.Success)
                {
                    int index = hideout.Index;
                    int size = hideout.Length;

                    Console.WriteLine($"Hideout found at index {index} and it is with size {size}!");
                    break;
                }
            }
        }
    }
}
