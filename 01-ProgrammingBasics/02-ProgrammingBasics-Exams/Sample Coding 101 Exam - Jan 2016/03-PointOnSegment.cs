using System;

namespace _03_PointOnSegment
{
    class Program
    {
        static void Main(string[] args)
        {
            int first = int.Parse(Console.ReadLine());
            int second = int.Parse(Console.ReadLine());
            int point = int.Parse(Console.ReadLine());

            if (point >= Math.Min(first, second) && point <= Math.Max(first, second))
            {
                Console.WriteLine("in");
                Console.WriteLine(Math.Min(Math.Abs(first - point), Math.Abs(second - point)));
            }
            else
            {
                Console.WriteLine("out");
                Console.WriteLine(Math.Min(Math.Abs(first - point), Math.Abs(second - point)));
            }
        }
    }
}
