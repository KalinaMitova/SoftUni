using System;

namespace _07_CakeIngredients
{
    class Program
    {
        static void Main(string[] args)
        {
            string ingredients = string.Empty;
            int counter = 0;

            do
            {
                ingredients = Console.ReadLine();
                if (ingredients != "Bake!")
                {
                    Console.WriteLine($"Adding ingredient {ingredients}.");
                    counter++;
                }
            } while (ingredients != "Bake!");

            Console.WriteLine($"Preparing cake with {counter} ingredients.");
        }
    }
}
