namespace _03_SkiTrip
{
    using System;

    class Program
    {
        static void Main(string[] args)
        {
            double onePersonRoomPrice = 18.0;
            double apartmentPrice = 25.0;
            double presidentApartmentPrice = 35.0;

            string roomForOnePerson = "room for one person";
            string apartment = "apartment";
            string presidentApartment = "president apartment";

            string positive = "positive";
            string negative = "negative";

            int days = int.Parse(Console.ReadLine());
            string roomType = Console.ReadLine();
            string grade = Console.ReadLine();

            double discount = 1;
            double roomPrice = 0.0;

            if(roomType == apartment)
            {
                roomPrice = apartmentPrice;

                if (days < 10)
                {
                    discount = 0.7;
                }
                else if(days <= 15)
                {
                    discount = 0.65;
                }
                else
                {
                    discount = 0.5;
                }
            }
            else if (roomType == presidentApartment)
            {
                roomPrice = presidentApartmentPrice;

                if (days < 10)
                {
                    discount = 0.9;
                }
                else if (days <= 15)
                {
                    discount = 0.85;
                }
                else
                {
                    discount = 0.80;
                }
            }
            else
            {
                roomPrice = onePersonRoomPrice;
            }

            double totalPrice = ((days - 1) * roomPrice) * discount;

            if(grade == positive)
            {
                totalPrice *= 1.25;
            }
            else if(grade == negative)
            {
                totalPrice *= 0.90;
            }

            Console.WriteLine("{0:F2}", totalPrice);
        }
    }
}
