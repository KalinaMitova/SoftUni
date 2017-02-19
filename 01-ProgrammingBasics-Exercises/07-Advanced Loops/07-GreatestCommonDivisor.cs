using System;

namespace _07_GreatestCommonDivisor
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());

            while (b != 0)
            {
                var t = b;
                b = a % b;
                a = t;
            }

            Console.WriteLine(a);
        }
    }
}
