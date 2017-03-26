using System;

namespace _01_GrapeAndRakia
{
    class Program
    {
        static void Main(string[] args)
        {
            double vineyardArea = double.Parse(Console.ReadLine());
            double quantity = double.Parse(Console.ReadLine());
            double waste = double.Parse(Console.ReadLine());

            double totalGrapes = (vineyardArea * quantity) - waste;
            double grapesForRakia = totalGrapes * 0.45;
            double grapesForSale = totalGrapes * 0.55;
            double rakia = grapesForRakia / 7.5;

            Console.WriteLine("{0:F2}", rakia * 9.8);
            Console.WriteLine("{0:F2}", grapesForSale * 1.5);
        }
    }
}
