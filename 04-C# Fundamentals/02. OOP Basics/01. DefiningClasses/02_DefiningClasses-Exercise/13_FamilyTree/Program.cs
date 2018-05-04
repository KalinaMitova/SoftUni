using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    public static void Main()
    {
        List<Person> people = new List<Person>();
        List<FamilyRealtionship> familyRelationships = new List<FamilyRealtionship>();

        string firstPersonInput = Console.ReadLine();

        var firstPerson = PersonParser(firstPersonInput);
        people.Add(firstPerson);
        
        string input;
        while ((input = Console.ReadLine()) != "End")
        {
            string[] tokens = input.Split("-".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

            if(tokens.Length == 2)
            {
                Person parent = PersonParser(tokens[0]);
                Person children = PersonParser(tokens[1]);

                var familyRelationshipParent = AddPersonIfNotExists(people, parent);
                var familyRelationshipChildren = AddPersonIfNotExists(people, children);

                var familyRelationship = new FamilyRealtionship(familyRelationshipParent, familyRelationshipChildren);

                familyRelationships.Add(familyRelationship);
            }
            else if (tokens.Length == 1)
            {
                string[] personInfo = tokens[0].Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                string firstName = personInfo[0];
                string lastName = personInfo[1];
                string birthday = personInfo[2];

                var persons = people
                    .Where(p => p.FirstName == firstName && p.LastName == lastName || p.Birthday == birthday)
                    .ToList();

                if (persons.Count() == 0)
                {
                    Person newPerson = new Person(firstName, lastName, birthday);
                    people.Add(newPerson);
                }
                else
                {
                    foreach (var person in persons)
                    {
                        person.FirstName = firstName;
                        person.LastName = lastName;
                        person.Birthday = birthday;
                    }
                }
            }
        }

        var parents = familyRelationships
            .Where(p => p.Children.FirstName == firstPerson.FirstName && p.Children.LastName == firstPerson.LastName && p.Children.Birthday == firstPerson.Birthday)
            .Select(p => p.Parent)
            .ToList();

        var childrens = familyRelationships
            .Where(p => p.Parent.FirstName == firstPerson.FirstName && p.Parent.LastName == firstPerson.LastName && p.Parent.Birthday == firstPerson.Birthday)
            .Select(p => p.Children)
            .ToList();

        Console.WriteLine($"{firstPerson.FirstName} {firstPerson.LastName} {firstPerson.Birthday}");
        Console.WriteLine("Parents:");
        foreach (var parent in parents)
        {
            Console.WriteLine($"{parent.FirstName} {parent.LastName} {parent.Birthday}");
        }
        Console.WriteLine("Children:");
        foreach (var children in childrens)
        {
            Console.WriteLine($"{children.FirstName} {children.LastName} {children.Birthday}");
        }
    }      
    
    public static Person AddPersonIfNotExists(List<Person> people, Person personToAdd)
    {
        var person = people.FirstOrDefault(p =>
            (p.FirstName != null &&
            p.LastName != null &&
            p.FirstName == personToAdd.FirstName && 
            p.LastName == personToAdd.LastName) || 
            (p.Birthday != null &&
            p.Birthday == personToAdd.Birthday));

        if (person == null)
        {
            person = personToAdd;
            people.Add(person);
        }

        return person;
    }

    public static Person PersonParser(string personInput)
    {
        string[] parentInput = personInput.Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

        Person person = new Person();
        if (parentInput.Length == 1)
        {
            string birthday = parentInput[0];
            person = new Person(birthday);
        }
        else if (parentInput.Length == 2)
        {
            string firstName = parentInput[0];
            string lastName = parentInput[1];
            person = new Person(firstName, lastName);
        }

        return person;
    }
}