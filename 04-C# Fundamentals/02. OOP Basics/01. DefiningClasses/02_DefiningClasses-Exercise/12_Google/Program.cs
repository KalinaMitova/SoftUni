using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

public class Program
{
    public static void Main()
    {
        List<Person> people = new List<Person>();

        string input;
        while ((input = Console.ReadLine()) != "End")
        {
            string[] tokens = input.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);

            string personName = tokens[0];
            string info = tokens[1];

            if(!people.Any(p => p.Name == personName))
            {
                people.Add(new Person(personName));
            }

            Person person = people.Single(p => p.Name == personName);

            switch (info)
            {
                case "company":
                    {
                        string companyName = tokens[2];
                        string companyDepartment = tokens[3];
                        decimal companySalary = decimal.Parse(tokens[4], CultureInfo.InvariantCulture);

                        person.Company = new Company(companyName, companyDepartment, companySalary);
                    }
                    break;
                case "pokemon":
                    {
                        string pokemonName = tokens[2];
                        string pokemonType = tokens[3];

                        person.Pokemons.Add(new Pokemon(pokemonName, pokemonType));
                    }
                    break;
                case "parents":
                    {
                        string name = tokens[2];
                        string birthday = tokens[3];

                        person.Parents.Add(new FamilyMember(name, birthday));
                    }
                    break;
                case "children":
                    {
                        string name = tokens[2];
                        string birthday = tokens[3];

                        person.Childrens.Add(new FamilyMember(name, birthday));
                    }
                    break;
                case "car":
                    {
                        string model = tokens[2];
                        string speed = tokens[3];

                        person.Car = new Car(model, speed);
                    }
                    break;
            }
        }

        string personInfo = Console.ReadLine();

        Console.WriteLine(people.Single(p => p.Name == personInfo));
    }
}