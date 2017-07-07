using System;

namespace _01_HousePrice
{
    class Program
    {
        static void Main(string[] args)
        {
            double smallRoomArea = double.Parse(Console.ReadLine());
            double kitchenArea = double.Parse(Console.ReadLine());
            decimal price = decimal.Parse(Console.ReadLine());

            double bathroomArea = (smallRoomArea / 2);
            double secondRoomArea = (smallRoomArea * 0.1) + smallRoomArea;
            double thirdRoomArea = (secondRoomArea * 0.1) + secondRoomArea;

            double corridor = (smallRoomArea + secondRoomArea + thirdRoomArea + kitchenArea + bathroomArea) * 0.05;
            double houseArea = smallRoomArea + secondRoomArea + thirdRoomArea + kitchenArea + bathroomArea + corridor;

            decimal totalPrice = (decimal)houseArea * price;

            Console.WriteLine(Math.Round(totalPrice, 2));
        }
    }
}
