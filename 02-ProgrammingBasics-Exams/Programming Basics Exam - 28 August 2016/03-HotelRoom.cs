using System;

namespace _03_HotelRoom
{
    class Program
    {
        static void Main(string[] args)
        {
            string month = Console.ReadLine().ToLower();
            int nights = int.Parse(Console.ReadLine());

            decimal studioPrice = 0.0m;
            decimal apartmentPrice = 0.0m;

            decimal studioDiscount = 0.0m;
            decimal apartmentDiscount = nights > 14 ? 0.1m : 0.0m;

            switch (month)
            {
                case "may":
                case "october":
                    studioPrice = 50m;
                    apartmentPrice = 65m;
                    if (nights > 7 && nights <= 14) studioDiscount = 0.05m;
                    else if (nights > 14) studioDiscount = 0.3m;
                    break;
                case "june":
                case "september":
                    studioPrice = 75.20m;
                    apartmentPrice = 68.7m;
                    if (nights > 14) studioDiscount = 0.2m;
                    break;
                case "july":
                case "august":
                    studioPrice = 76m;
                    apartmentPrice = 77m;
                    break;
                default:
                    Console.WriteLine("unknown month");
                    return;
            }

            decimal apartmentTotalPrice = (apartmentPrice * nights) - ((apartmentPrice * nights) * apartmentDiscount);
            decimal studioTotalPrice = (studioPrice * nights) - ((studioPrice * nights) * studioDiscount);

            Console.WriteLine("Apartment: {0:F2} lv.", apartmentTotalPrice);
            Console.WriteLine("Studio: {0:F2} lv.", studioTotalPrice);
        }
    }
}
