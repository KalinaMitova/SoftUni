using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_RestaurantDiscount
{
    class Program
    {
        static void Main(string[] args)
        {
            int countOfPeople = int.Parse(Console.ReadLine());
            string servicePackage = Console.ReadLine();

            string hall = string.Empty;
            double hallPrice = 0d;
            double packagePrice = 0d;
            double discount = 0d;

            if (countOfPeople > 0 && countOfPeople <= 50)
            {
                hall = "Small Hall";
                hallPrice = 2500;
            }
            else if (countOfPeople > 50 && countOfPeople <= 100)
            {
                hall = "Terrace";
                hallPrice = 5000;
            }
            else if (countOfPeople > 100 && countOfPeople <= 120)
            {
                hall = "Great Hall";
                hallPrice = 7500;
            }
            else
            {
                Console.WriteLine("We do not have an appropriate hall.");
                return;
            }

            switch (servicePackage.ToLower())
            {
                case "normal":
                    packagePrice = 500;
                    discount = 0.95;
                    break;
                case "gold":
                    packagePrice = 750;
                    discount = 0.9;
                    break;
                case "platinum":
                    packagePrice = 1000;
                    discount = 0.85;
                    break;
                default:
                    Console.WriteLine("uncknown package");
                    return;
            }

            double pricePerPerson = ((hallPrice + packagePrice) * discount) / countOfPeople;

            Console.WriteLine($"We can offer you the {hall}");
            Console.WriteLine($"The price per person is {pricePerPerson:F2}$");
        }
    }
}
