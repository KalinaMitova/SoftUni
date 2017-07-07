using System;

namespace _02_Styrofoam
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            double houseArea = double.Parse(Console.ReadLine());
            int numOfWidnows = int.Parse(Console.ReadLine());
            double styrofoamInPackages = double.Parse(Console.ReadLine());
            double styrofoamPackagePrice = double.Parse(Console.ReadLine());

            double houseAreaWithoutWindows = houseArea - (numOfWidnows * 2.4);
            houseAreaWithoutWindows += houseAreaWithoutWindows * 0.1;
            double neededStyrofoam = Math.Ceiling(houseAreaWithoutWindows / styrofoamInPackages);
            double neededMoneyForStyrofoam = neededStyrofoam * styrofoamPackagePrice;

            if(budget >= neededMoneyForStyrofoam)
            {
                Console.WriteLine("Spent: {0:F2}", neededMoneyForStyrofoam);
                Console.WriteLine("Left: {0:F2}", budget - neededMoneyForStyrofoam);
            }
            else
            {
                Console.WriteLine("Need more: {0:F2}", neededMoneyForStyrofoam - budget);
            }
        }
    }
}
