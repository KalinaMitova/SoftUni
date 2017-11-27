using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_OpinionPoll
{
    class StartUp
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            List<Person> persons = new List<Person>();

            for (int i = 0; i < n; i++)
            {
                string[] args = Console.ReadLine().Split();

                string name = args[0];
                int age = int.Parse(args[1]);

                persons.Add(new Person(name, age));
            }

            foreach (Person person in persons.OrderBy(p => p.Name))
            {
                if(person.Age > 30)
                {
                    Console.WriteLine(person);
                }
            }
        }
    }
}
