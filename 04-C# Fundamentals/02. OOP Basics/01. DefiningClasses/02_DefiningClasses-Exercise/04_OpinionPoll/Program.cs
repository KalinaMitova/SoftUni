using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    public static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        List<Person> people = new List<Person>(n);

        for (int i = 0; i < n; i++)
        {
            string[] nameAge = Console.ReadLine().Split();

            string name = nameAge[0];
            int age = int.Parse(nameAge[1]);

            Person person = new Person(name, age);
            people.Add(person);
        }

        List<Person> filteredPeople = people
            .Where(p => p.Age > 30)
            .OrderBy(p => p.Name)
            .ToList();

        foreach (var person in filteredPeople)
        {
            Console.WriteLine($"{person.Name} - {person.Age}");
        }
    }
}