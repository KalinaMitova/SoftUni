using System;

namespace _07_FruitShop
{
    class Program
    {
        static void Main(string[] args)
        {
            string fruit = Console.ReadLine().ToLower();
            string dayOfWeek = Console.ReadLine().ToLower();
            double quantity = double.Parse(Console.ReadLine());
            double? price = null;

            if (dayOfWeek == "monday" || dayOfWeek == "tuesday" ||
                dayOfWeek == "wednesday" || dayOfWeek == "thursday" ||
                dayOfWeek == "friday")
            {
                switch (fruit)
                {
                    case "banana":
                        price = quantity * 2.5;
                        break;
                    case "apple":
                        price = quantity * 1.2;
                        break;
                    case "orange":
                        price = quantity * 0.85;
                        break;
                    case "grapefruit":
                        price = quantity * 1.45;
                        break;
                    case "kiwi":
                        price = quantity * 2.7;
                        break;
                    case "pineapple":
                        price = quantity * 5.5;
                        break;
                    case "grapes":
                        price = quantity * 3.85;
                        break;
                }
            }
            else if (dayOfWeek == "saturday" || dayOfWeek == "sunday")
            {
                switch (fruit)
                {
                    case "banana":
                        price = quantity * 2.7;
                        break;
                    case "apple":
                        price = quantity * 1.25;
                        break;
                    case "orange":
                        price = quantity * 0.90;
                        break;
                    case "grapefruit":
                        price = quantity * 1.60;
                        break;
                    case "kiwi":
                        price = quantity * 3.0;
                        break;
                    case "pineapple":
                        price = quantity * 5.6;
                        break;
                    case "grapes":
                        price = quantity * 4.2;
                        break;
                }
            }

            if (price.HasValue)
            {
                Console.WriteLine(Math.Round(price.Value, 2));
            }
            else
            {
                Console.WriteLine("error");
            }
        }
    }
}
