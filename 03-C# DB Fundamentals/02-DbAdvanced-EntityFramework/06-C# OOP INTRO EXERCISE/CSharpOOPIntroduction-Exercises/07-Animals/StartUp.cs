using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07_Animals
{
    class StartUp
    {
        static void Main()
        {
            Dictionary<string, Animal> animals = new Dictionary<string, Animal>();

            string firstLine;
            while ((firstLine = Console.ReadLine()) != "Beast!")
            {
                string[] secondLine = Console.ReadLine().Split();                

                try
                {
                    string name = secondLine[0];
                    int age = int.Parse(secondLine[1]);
                    string gender = secondLine[2];

                    switch (firstLine)
                    {
                        case "Dog":
                            Dog dog = new Dog(name, age, gender);
                            animals.Add("Dog", dog);
                            break;
                        case "Cat":
                            Cat cat = new Cat(name, age, gender);
                            animals.Add("Cat", cat);
                            break;
                        case "Frog":
                            Frog frog = new Frog(name, age, gender);
                            animals.Add("Frog", frog);
                            break;
                        case "Kitten":
                            Kitten kitten = new Kitten(name, age, gender);
                            animals.Add("Kitten", kitten);
                            break;
                        case "Tomcat":
                            Tomcat tomcat = new Tomcat(name, age, gender);
                            animals.Add("Tomcat", tomcat);
                            break;
                        default:
                            throw new ArgumentException("Invalid input!");
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }                
            }

            foreach (var animal in animals)
            {
                Console.WriteLine(animal.Key);
                Console.WriteLine($"{animal.Value.Name} {animal.Value.Age} {animal.Value.Gender}");
                Console.WriteLine(animal.Value.ProduceSound());
            }
        }
    }
}
