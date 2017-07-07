using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09_ExtractMiddleElements
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] n = Console.ReadLine().Split(' ')
                .Select(int.Parse).ToArray();

            int length = n.Length;

            if (length == 1)
            {
                Console.WriteLine($"{{ {n[0]} }}");
            }
            else if (length % 2 == 0)
            {
                Console.WriteLine($"{{ {n[length / 2 - 1]}, {n[(length / 2)]} }}");
            }
            else
            {
                Console.WriteLine($"{{ {n[length / 2 - 1]}, {n[length / 2]}, {n[length / 2 + 1]} }}");
            }
        }
    }
}
