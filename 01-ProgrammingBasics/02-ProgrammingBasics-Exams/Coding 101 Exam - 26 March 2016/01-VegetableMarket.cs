using System;

namespace _02.VegetableMarket
{
    class Program
    {
        static void Main(string[] args)
        {
            double vegetablePrice = double.Parse(Console.ReadLine());
            double fruitPrice = double.Parse(Console.ReadLine());
            int vegetableWeight = int.Parse(Console.ReadLine());
            int fruitWeight = int.Parse(Console.ReadLine());

            double eur = 1.94d;

            double totalCost = (vegetablePrice * vegetableWeight + fruitPrice * fruitWeight) / eur;

            Console.WriteLine(totalCost);
        }
    }
}