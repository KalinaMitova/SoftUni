using System;

namespace _02_Pets
{
    class Program
    {
        static void Main(string[] args)
        {
            int days = int.Parse(Console.ReadLine());
            int totalFood = int.Parse(Console.ReadLine());

            double dogFoodPerDayInKg = double.Parse(Console.ReadLine());
            double catFoodPerDayInKg = double.Parse(Console.ReadLine());
            double turtleFoodPerDayInGrams = double.Parse(Console.ReadLine());

            double eatenFood = days * (dogFoodPerDayInKg + catFoodPerDayInKg + (turtleFoodPerDayInGrams / 1000));

            if (totalFood >= eatenFood)
            {
                Console.WriteLine("{0} kilos of food left.", Math.Floor(totalFood - eatenFood));
            }
            else
            {
                Console.WriteLine("{0} more kilos of food are needed.", Math.Ceiling(eatenFood - totalFood));
            }
        }
    }
}
