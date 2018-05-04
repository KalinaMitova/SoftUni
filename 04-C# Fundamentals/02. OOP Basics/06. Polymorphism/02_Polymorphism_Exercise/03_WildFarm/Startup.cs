using System;
using System.Collections.Generic;

namespace _03_WildFarm
{
    public class Startup
    {
        public static void Main()
        {
            List<Animal> animals = new List<Animal>();

            AnimalFactory animalFactory = new AnimalFactory();
            FoodFactory foodFactory = new FoodFactory();
            
            string input;
            while ((input = Console.ReadLine()) != "End")
            {
                string[] animalTokens = input.Split();
                string[] foodTokens = Console.ReadLine().Split();

                Animal animal = animalFactory.GetType(animalTokens);
                Food food = foodFactory.GetType(foodTokens);

                string animalSound = animal.ProduceSound();
                Console.WriteLine(animalSound); 

                try
                {
                    animal.Eat(food);
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }

                animals.Add(animal);
            }

            foreach (var animal in animals)
            {
                Console.WriteLine(animal);
            }
        }
    }
}
