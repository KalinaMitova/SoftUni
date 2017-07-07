using System;

namespace _01_TriangleArea
{
    class Program
    {
        static void Main(string[] args)
        {
            int x1 = int.Parse(Console.ReadLine());
            int y1 = int.Parse(Console.ReadLine());
            int x2 = int.Parse(Console.ReadLine());
            int y2 = int.Parse(Console.ReadLine());
            int x3 = int.Parse(Console.ReadLine());
            int y3 = int.Parse(Console.ReadLine());

            int a = Math.Abs(x3 - x2);
            int h = Math.Abs(y1 - y2);

            double area = (a * h) / 2.0;

            Console.WriteLine(area);
        }
    }
}
