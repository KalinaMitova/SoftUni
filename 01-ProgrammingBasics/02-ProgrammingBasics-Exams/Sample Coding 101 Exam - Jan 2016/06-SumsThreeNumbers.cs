using System;

namespace _06_SumsThreeNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());
            int c = int.Parse(Console.ReadLine());

            int sum = a + b + c;

            if (sum - c == c)
            {
                Console.WriteLine("{0} + {1} = {2}", Math.Min(a, b), Math.Max(a, b), c);
            }
            else if (sum - b == b)
            {
                Console.WriteLine("{0} + {1} = {2}", Math.Min(c, a), Math.Max(c, a), b);
            }
            else if (sum - a == a)
            {
                Console.WriteLine("{0} + {1} = {2}", Math.Min(b, c), Math.Max(b, c), a);
            }
            else
            {
                Console.WriteLine("no");
            }
        }
    }
}
