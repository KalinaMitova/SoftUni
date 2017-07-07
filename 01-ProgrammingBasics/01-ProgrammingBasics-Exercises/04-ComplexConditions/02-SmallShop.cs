using System;

namespace _02_SmallShop
{
    class Program
    {
        static void Main(string[] args)
        {
            string product = Console.ReadLine().ToLower();
            string city = Console.ReadLine().ToLower();
            double quantity = double.Parse(Console.ReadLine());
            double? price = null;

            if(city == "sofia")
            {
                if(product == "coffee") price = quantity * 0.5;
                else if (product == "water") price = quantity * 0.8;
                else if (product == "beer") price = quantity * 1.2;
                else if (product == "sweets") price = quantity * 1.45;
                else if (product == "peanuts") price = quantity * 1.6;
            }
            else if (city == "plovdiv")
            {
                if (product == "coffee") price = quantity * 0.4;
                else if (product == "water") price = quantity * 0.7;
                else if (product == "beer") price = quantity * 1.15;
                else if (product == "sweets") price = quantity * 1.30;
                else if (product == "peanuts") price = quantity * 1.50;
            }
            else if (city == "varna")
            {
                if (product == "coffee") price = quantity * 0.45;
                else if (product == "water") price = quantity * 0.70;
                else if (product == "beer") price = quantity * 1.1;
                else if (product == "sweets") price = quantity * 1.35;
                else if (product == "peanuts") price = quantity * 1.55;
            }

            Console.WriteLine(price);
        }
    }
}
