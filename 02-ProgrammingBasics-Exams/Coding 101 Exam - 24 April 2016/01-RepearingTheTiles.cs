using System;

namespace _03.RepairingTheTiles
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            double w = double.Parse(Console.ReadLine());
            double l = double.Parse(Console.ReadLine());
            int m = int.Parse(Console.ReadLine());
            int o = int.Parse(Console.ReadLine());

            int area = n * n;
            int benchArea = m * o;
            double tileArea = w * l;
            double numOfTiles = (area - benchArea) / tileArea;
            double timeForRepairing = numOfTiles * 0.2;

            Console.WriteLine(numOfTiles);
            Console.WriteLine(timeForRepairing);
        }
    }
}
