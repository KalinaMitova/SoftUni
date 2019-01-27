namespace _03_EnergyBooster
{
    using System;

    class Program
    {
        static void Main()
        {
            string fruit = Console.ReadLine();
            string pack = Console.ReadLine();
            int purchaseCount = int.Parse(Console.ReadLine());

            double price = 0.0;
            int countInPack = 0;
            
            if(pack == "small")
            {
                countInPack = 2;

                if(fruit == "Watermelon")
                {
                    price = 56;
                }
                else if (fruit == "Mango")
                {
                    price = 36.66;
                }
                else if (fruit == "Pineapple")
                {
                    price = 42.10;
                }
                else if (fruit == "Raspberry")
                {
                    price = 20;
                }
            }
            else if(pack == "big")
            {
                countInPack = 5;

                if (fruit == "Watermelon")
                {
                    price = 28.70;
                }
                else if (fruit == "Mango")
                {
                    price = 19.60;
                }
                else if (fruit == "Pineapple")
                {
                    price = 24.80;
                }
                else if (fruit == "Raspberry")
                {
                    price = 15.20;
                }
            }

            double totalPrice = purchaseCount * (price * countInPack);

            if(totalPrice >= 400 && totalPrice <= 1000)
            {
                totalPrice *= 0.85;
            }
            else if(totalPrice > 1000)
            {
                totalPrice *= 0.50;
            }

            Console.WriteLine("{0:F2} lv.", totalPrice);
        }
    }
}
