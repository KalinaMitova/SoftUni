using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05_ComparingObjects
{
    public class Program
    {
        public static void Main()
        {
            List<Person> people = new List<Person>();

            string input;
            while((input = Console.ReadLine()) != "END")
            {
                string[] tokens = input.Split();
                string name = tokens[0];
                int age = int.Parse(tokens[1]);
                string town = tokens[1];

                Person person = new Person(name, age, town);

                people.Add(person);
            }

            int n = int.Parse(Console.ReadLine());

            Person personToCompare = people[n - 1];

            int numberOfEqualPeople = 0;
            int numberOfNotEqualPeople = 0;

            int totalNumberOfPeople = people.Count;

            for (int i = 0; i < people.Count; i++)
            {
                if(i != n - 1)
                {
                    int compareResult = people[i].CompareTo(personToCompare);

                    if (compareResult == 0)
                    {
                        numberOfEqualPeople++;
                    }
                    else
                    {
                        numberOfNotEqualPeople++;
                    }
                }
            }

            if(numberOfEqualPeople == 0)
            {
                Console.WriteLine("No matches");
            }
            else
            {
                numberOfEqualPeople++;
                Console.WriteLine($"{numberOfEqualPeople} {numberOfNotEqualPeople} {totalNumberOfPeople}");
            }
        }
    }
}
