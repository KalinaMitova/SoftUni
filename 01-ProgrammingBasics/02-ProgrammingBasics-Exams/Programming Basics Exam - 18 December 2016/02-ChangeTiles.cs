using System;

namespace _02_ChangeTiles
{
    class Program
    {
        static void Main(string[] args)
        {
            double money = double.Parse(Console.ReadLine());
            double floorWidth = double.Parse(Console.ReadLine());
            double floorHeight = double.Parse(Console.ReadLine());
            double triangleSideA = double.Parse(Console.ReadLine());
            double triangleHeight = double.Parse(Console.ReadLine());
            double tilePrice = double.Parse(Console.ReadLine());
            double workmanPrice = double.Parse(Console.ReadLine());

            double floorArea = floorWidth * floorHeight;
            double tileArea = (triangleSideA * triangleHeight) / 2;
            double totalTiles = Math.Ceiling(floorArea / tileArea) + 5;
            double neededMoney = (tilePrice * totalTiles) + workmanPrice;
            
            if (money >= neededMoney)
            {
                Console.WriteLine("{0:F2} lv left.", money - neededMoney);
            }
            else
            {
                Console.WriteLine("You'll need {0:F2} lv more.", neededMoney - money);
            }
        }
    }
}
