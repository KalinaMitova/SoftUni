using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06_StrategyPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            SortedSet<Person> peopleSortedByName = new SortedSet<Person>(new PersonNameComparator());
            SortedSet<Person> peopleSortedByAge = new SortedSet<Person>(new PersonAgeComparator());

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split();
                string name = input[0];
                int age = int.Parse(input[1]);

                Person person = new Person(name, age);

                peopleSortedByName.Add(person);
                peopleSortedByAge.Add(person);
            }

            foreach (var person in peopleSortedByName)
            {
                Console.WriteLine(person);
            }

            foreach (var person in peopleSortedByAge)
            {
                Console.WriteLine(person);
            }
        }
    }
}
