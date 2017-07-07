using System;

namespace _03_CarToGo
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            string season = Console.ReadLine().ToLower();

            string carClass = "";
            string carType = "";
            double price = 0.0;

            if (budget <= 100)
            {
                carClass = "Economy class";
                switch (season)
                {
                    case "summer":
                        price = 0.35;
                        carType = "Cabrio";
                        break;
                    case "winter":
                        price = 0.65;
                        carType = "Jeep";
                        break;
                }
            }
            else if (budget > 100 && budget <= 500)
            {
                carClass = "Compact class";
                switch (season)
                {
                    case "summer":
                        price = 0.45;
                        carType = "Cabrio";
                        break;
                    case "winter":
                        price = 0.8;
                        carType = "Jeep";
                        break;
                }
            }
            else
            {
                carClass = "Luxury class";
                carType = "Jeep";
                price = 0.9;
            }

            Console.WriteLine(carClass);
            Console.WriteLine("{0} - {1:F2}", carType, budget * price);
        }
    }
}
