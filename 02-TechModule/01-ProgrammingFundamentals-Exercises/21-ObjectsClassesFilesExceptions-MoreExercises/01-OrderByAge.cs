using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_OrderByAge
{
    class Program
    {
        static void Main(string[] args)
        {
            var personsData = new List<Person>();

            var line = Console.ReadLine();

            while (line != "End")
            {
                var tokens = line.Split();

                var name = tokens[0];
                var id = tokens[1];
                var age = int.Parse(tokens[2]);

                var person = new Person
                {
                    Name = name,
                    Id = id,
                    Age = age
                };

                personsData.Add(person);

                line = Console.ReadLine();
            }

            foreach (var person in personsData.OrderBy(p => p.Age))
            {
                Console.WriteLine($"{person.Name} with ID: {person.Id} is {person.Age} years old.");
            }
        }
    }

    class Person
    {
        public string Name { get; set; }

        public string Id { get; set; }

        public int Age { get; set; }
    }
}
