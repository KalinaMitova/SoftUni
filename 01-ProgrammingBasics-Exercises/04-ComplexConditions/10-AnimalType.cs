using System;

namespace _10_AnimalType
{
    class Program
    {
        static void Main(string[] args)
        {
            string animal = Console.ReadLine();
            string animalType = "";

            switch (animal)
            {
                case "dog":
                    animalType = "mammal";
                    break;
                case "crocodile":
                case "tortoise":
                case "snake":
                    animalType = "reptile";
                    break;
                default:
                    animalType = "unknown";
                    break;
            }

            Console.WriteLine(animalType);
        }
    }
}
