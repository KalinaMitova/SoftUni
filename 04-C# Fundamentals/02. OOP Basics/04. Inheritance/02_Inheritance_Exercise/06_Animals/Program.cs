using System;
using System.Collections.Generic;

public class Program
{
    public static void Main()
    {
        List<Animal> animals = new List<Animal>();

        string animalType;
        while ((animalType = Console.ReadLine()) != "Beast!")
        {
            string[] tokens = Console.ReadLine().Split(" ".ToCharArray(), StringSplitOptions.None);

            string name = tokens[0];
            int age = int.Parse(tokens[1]);
            string gender = tokens[2];

            try
            {
                Animal animal;

                switch (animalType)
                {
                    case "Dog":
                        animal = new Dog(name, age, gender);
                        break;
                    case "Cat":
                        animal = new Cat(name, age, gender);
                        break;
                    case "Frog":
                        animal = new Frog(name, age, gender);
                        break;
                    case "Kitten":
                        animal = new Kitten(name, age);
                        break;
                    case "Tomcat":
                        animal = new Tomcat(name, age);
                        break;
                    default:
                        throw new ArgumentException("Invalid input!");
                }

                animals.Add(animal);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        foreach (var animal in animals)
        {
            Console.WriteLine(animal);
        }
    }
}