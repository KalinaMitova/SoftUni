using System;

namespace _04_Logistics
{
    class Program
    {
        static void Main(string[] args)
        {
            int numOfFreight = int.Parse(Console.ReadLine());

            int bus = 0;
            int truck = 0;
            int train = 0;
            int totalWeight = 0;
            double shippedWeight;
            decimal priceForTon;
            decimal averagePrice = 0;

            for (int i = 1; i <= numOfFreight; i++)
            {
                int weight = int.Parse(Console.ReadLine());

                if(weight > 0 && weight <= 3)
                {
                    priceForTon = 200m;
                    bus += weight;
                }
                else if(weight > 3 && weight <= 11)
                {
                    priceForTon = 175m;
                    truck += weight;
                }
                else
                {
                    priceForTon = 120m;
                    train += weight;
                }
                averagePrice += weight * priceForTon;
                totalWeight += weight;
            }

            averagePrice /= totalWeight;
            shippedWeight = bus + truck + train;

            Console.WriteLine("{0:F2}", averagePrice);
            Console.WriteLine("{0:F2}%", (bus / shippedWeight) * 100);
            Console.WriteLine("{0:F2}%", (truck / shippedWeight) * 100);
            Console.WriteLine("{0:F2}%", (train / shippedWeight) * 100);
        }
    }
}
