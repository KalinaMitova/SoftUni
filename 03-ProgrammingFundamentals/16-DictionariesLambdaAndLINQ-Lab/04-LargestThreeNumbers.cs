using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_LargestThreeNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

            var ordered = numbers.OrderBy(p => -p);

            var largestThreeNumbers = ordered.Take(3);

            Console.WriteLine(string.Join(" ", largestThreeNumbers));
        }
    }
}
