using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_CountRealNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine().Split(' ').Select(double.Parse).ToArray();
            var dict = new SortedDictionary<double, int>();

            foreach (var number in numbers)
            {
                if (dict.ContainsKey(number))
                {
                    dict[number]++;
                }
                else
                {
                    dict.Add(number, 1);
                }
            }

            foreach (var d in dict)
            {
                Console.WriteLine($"{d.Key} -> {d.Value}");
            }
        }
    }
}
