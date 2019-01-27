namespace _02_SchoolTrip
{
    using System;

    class Program
    {
        static void Main(string[] args)
        {
            int daysCount = int.Parse(Console.ReadLine());
            int foodInKgs = int.Parse(Console.ReadLine());

            double firstDogFoodPerDay = double.Parse(Console.ReadLine());
            double secondtDogFoodPerDay = double.Parse(Console.ReadLine());
            double thirdDogFoodPerDay = double.Parse(Console.ReadLine());

            double neededFood = daysCount * (firstDogFoodPerDay + secondtDogFoodPerDay + thirdDogFoodPerDay);

            if(foodInKgs >= neededFood)
            {
                double foodLeft = Math.Floor(foodInKgs - neededFood);
                Console.WriteLine("{0} kilos of food left.", foodLeft);
            }
            else
            {
                double needMoreFood = Math.Ceiling(neededFood - foodInKgs);
                Console.WriteLine("{0} more kilos of food are needed.", needMoreFood);
            }
        }
    }
}
