using System;

namespace _03_TruckDriver
{
    class Program
    {
        static void Main(string[] args)
        {
            string season = Console.ReadLine().ToLower();
            double kilometersPerMonth = double.Parse(Console.ReadLine());
            double sumPerKilometer = 0;

            if (kilometersPerMonth <= 5000)
            {
                switch (season)
                {
                    case "spring":
                    case "autumn":
                        sumPerKilometer = 0.75;
                        break;
                    case "summer":
                        sumPerKilometer = 0.9;
                        break;
                    case "winter":
                        sumPerKilometer = 1.05;
                        break;                        
                }
            }   
            else if (5000 < kilometersPerMonth && kilometersPerMonth <= 10000)
            {
                switch (season)
                {
                    case "spring":
                    case "autumn":
                        sumPerKilometer = 0.95;
                        break;
                    case "summer":
                        sumPerKilometer = 1.1;
                        break;
                    case "winter":
                        sumPerKilometer = 1.25;
                        break;
                }
            }         
            else if (10000 < kilometersPerMonth && kilometersPerMonth <= 20000)
            {
                sumPerKilometer = 1.45;
            }

            double earnedMoney = kilometersPerMonth * sumPerKilometer * 4;
            earnedMoney -= earnedMoney * 0.1;

            Console.WriteLine("{0:F2}", earnedMoney);
        }
    }
}
