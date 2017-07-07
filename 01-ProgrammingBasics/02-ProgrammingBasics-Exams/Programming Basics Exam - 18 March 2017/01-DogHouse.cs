using System;

namespace _01_DogHouse
{
    class Program
    {
        static void Main(string[] args)
        {
            double a = double.Parse(Console.ReadLine());
            double b = double.Parse(Console.ReadLine());

            double shortSide = a / 2;

            double door = (a / 5) * (a / 5);
            double sideWalls = (a * shortSide) * 2;
            double frontRearWalls = (shortSide * shortSide) * 2;
            double frontRearTriangleWalls = (b - a / 2) * shortSide;
            double roof = (a * shortSide) * 2;

            Console.WriteLine("{0:F2}", (sideWalls + frontRearWalls + frontRearTriangleWalls - door) / 3);
            Console.WriteLine("{0:F2}", roof / 5);
        }
    }
}
