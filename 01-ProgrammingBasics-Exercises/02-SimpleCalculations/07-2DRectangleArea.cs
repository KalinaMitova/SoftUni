using System;

namespace _07.__2DRectangleArea
{
    class Program
    {
        static void Main(string[] args)
        {
            double x1 = double.Parse(Console.ReadLine());
            double y1 = double.Parse(Console.ReadLine());
            double x2 = double.Parse(Console.ReadLine());
            double y2 = double.Parse(Console.ReadLine());

            double sideA = Math.Max(x1, x2) - Math.Min(x1, x2);
            double sideB = Math.Max(y1, y2) - Math.Min(y1, y2);

            Console.WriteLine(sideA * sideB);
            Console.WriteLine(sideA * 2 + sideB * 2);
        }
    }
}