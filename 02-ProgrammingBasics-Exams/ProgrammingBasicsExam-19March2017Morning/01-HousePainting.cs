using System;

namespace _01_HousePainting
{
    class Program
    {
        static void Main(string[] args)
        {
            double x = double.Parse(Console.ReadLine());
            double y = double.Parse(Console.ReadLine());
            double h = double.Parse(Console.ReadLine());

            double door = 1.2 * 2;
            double windows = 1.5 * 1.5 * 2;
            double walls = ((x * x) * 2) + (x * y) * 2;

            double roofFrontBackSide = x * h;
            double roofRearSides = 2 * (x * y);

            double totalGreenPaint = walls - door - windows;
            double totalRedPaint = roofFrontBackSide + roofRearSides;

            Console.WriteLine("{0:F2}", totalGreenPaint / 3.4);
            Console.WriteLine("{0:F2}", totalRedPaint / 4.3);
        }
    }
}
