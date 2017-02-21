using System;

namespace _02_Bricks
{
    class Program
    {
        static void Main(string[] args)
        {
            int x = int.Parse(Console.ReadLine());
            int w = int.Parse(Console.ReadLine());
            int m = int.Parse(Console.ReadLine());

            Console.WriteLine(Math.Ceiling(x / (double)(w * m)));
        }
    }
}
