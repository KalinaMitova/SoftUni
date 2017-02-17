using System;

namespace _03_Trip
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = Convert.ToDouble(Console.ReadLine());
            string season = Console.ReadLine().ToLower();

            double spentMoney = 0;
            string restingPlace = "";

            if (budget <= 100)
            {
                Console.WriteLine("Somewhere in Bulgaria");
                switch (season)
                {
                    case "summer":
                        spentMoney = budget * 0.3;
                        restingPlace = "Camp";
                        break;
                    case "winter":
                        spentMoney = budget * 0.7;
                        restingPlace = "Hotel";
                        break;
                }
            }
            else if (budget <= 1000)
            {
                Console.WriteLine("Somewhere in Balkans");
                switch (season)
                {
                    case "summer":
                        spentMoney = budget * 0.4;
                        restingPlace = "Camp";
                        break;
                    case "winter":
                        spentMoney = budget * 0.8;
                        restingPlace = "Hotel";
                        break;
                }
            }
            else
            {
                Console.WriteLine("Somewhere in Europe");
                spentMoney = budget * 0.9;
                restingPlace = "Hotel";
            }

            Console.WriteLine("{0} - {1:F2}", restingPlace, spentMoney);
        }
    }
}
