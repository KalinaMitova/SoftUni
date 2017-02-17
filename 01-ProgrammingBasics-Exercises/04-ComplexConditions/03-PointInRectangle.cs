using System;

namespace _03_PointInRectangle
{
    class Program
    {
        static void Main(string[] args)
        {
            double x1 = double.Parse(Console.ReadLine());
            double y1 = double.Parse(Console.ReadLine());
            double x2 = double.Parse(Console.ReadLine());
            double y2 = double.Parse(Console.ReadLine());
            double x = double.Parse(Console.ReadLine());
            double y = double.Parse(Console.ReadLine());

            if (x >= x1 && x <= x2 && y >= y1 && y <= y2) Console.WriteLine("inside");
            else Console.WriteLine("outside");
        }
    }
}
