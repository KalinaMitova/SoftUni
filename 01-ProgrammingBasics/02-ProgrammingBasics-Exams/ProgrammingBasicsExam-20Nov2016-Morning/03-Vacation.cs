using System;

namespace _03_Vacation
{
    class Program
    {
        static void Main(string[] args)
        {
            int adults = int.Parse(Console.ReadLine());
            int students = int.Parse(Console.ReadLine());
            int overnights = int.Parse(Console.ReadLine());
            string transport = Console.ReadLine();

            decimal priceForAdults;
            decimal priceForStudents;

            switch (transport)
            {
                case "train":
                    priceForAdults = 24.99m;
                    priceForStudents = 14.99m;
                    break;
                case "bus":
                    priceForAdults = 32.50m;
                    priceForStudents = 28.50m;
                    break;
                case "boat":
                    priceForAdults = 42.99m;
                    priceForStudents = 39.99m;
                    break;
                case "airplane":
                    priceForAdults = 70m;
                    priceForStudents = 50m;
                    break;
                default: return;
            }

            decimal totalTransportPrice = ((adults * priceForAdults) + (students * priceForStudents)) * 2;
            decimal overnightsPrice = overnights * 82.99m;

            if (adults + students >= 50 && transport == "train")
            {
                totalTransportPrice -= totalTransportPrice / 2;
            }

            decimal totalPrice = (totalTransportPrice + overnightsPrice) + ((totalTransportPrice + overnightsPrice) * 0.1m);

            Console.WriteLine("{0:F2}", totalPrice);
        }
    }
}
