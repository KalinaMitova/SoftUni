using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_PokeMon
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine()); // poke power
            int m = int.Parse(Console.ReadLine()); // distance
            int y = int.Parse(Console.ReadLine()); // exhaustionFactor
            int count = 0;

            double half = n / 2d;

            while (n >= m)
            {
                n -= m;
                count++;
                if (n == half && y > 0)
                {
                    n /= y;
                }
            }

            Console.WriteLine(n);
            Console.WriteLine(count);
        }
    }
}
