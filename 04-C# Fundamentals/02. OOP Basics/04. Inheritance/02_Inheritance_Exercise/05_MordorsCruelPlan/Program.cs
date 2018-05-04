namespace _05_MordorsCruelPlan
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        static void Main()
        {
            string[] items = Console.ReadLine().Split(" ".ToCharArray(), StringSplitOptions.None);

            List<Food> food = ReadFood(items);

            int totalHappiness = CalculateTotalHappiness(food);

            Mood mood = MoodFactory.GetType(totalHappiness);

            Console.WriteLine(mood);
        }

        private static int CalculateTotalHappiness(List<Food> food)
        {
            return food.Sum(f => f.Hapiness);
        }

        private static List<Food> ReadFood(string[] items)
        {
            List<Food> food = new List<Food>();

            foreach (var item in items)
            {
                Food currentFood = FoodFactory.GetType(item);
                food.Add(currentFood);
            }

            return food;
        }
    }
}
