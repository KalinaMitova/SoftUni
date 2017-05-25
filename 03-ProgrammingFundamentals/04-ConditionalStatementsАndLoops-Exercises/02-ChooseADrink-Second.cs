using System;

namespace _01_ChooseADrink
{
    class Program
    {
        static void Main(string[] args)
        {
            string profession = Console.ReadLine();
            int quantity = int.Parse(Console.ReadLine());

            string drink = string.Empty;
            double price;

            switch (profession)
            {
                case "Athlete":
                    drink = "Water";
                    price = 0.7;
                    break;
                case "Businessman":
                case "Businesswoman":
                    drink = "Coffee";
                    price = 1;
                    break;
                case "SoftUni Student":
                    drink = "Beer";
                    price = 1.7;
                    break;
                default:
                    drink = "Tea";
                    price = 1.2;
                    break;
            }

            double totalPrice = quantity * price;

            Console.WriteLine($"The {profession} has to pay {totalPrice:F2}.");
        }
    }
}
