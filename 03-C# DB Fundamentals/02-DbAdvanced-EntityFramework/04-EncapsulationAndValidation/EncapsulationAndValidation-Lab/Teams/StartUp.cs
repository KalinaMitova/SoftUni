using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teams
{
    class StartUp
    {
        static void Main(string[] args)
        {
            Team myTeam = new Team("Ludogorets");

            var lines = int.Parse(Console.ReadLine());
            //var persons = new List<Person>();

            for (int i = 0; i < lines; i++)
            {
                var cmdArgs = Console.ReadLine().Split();

                string firstName = cmdArgs[0];
                string lastName = cmdArgs[1];
                int age = int.Parse(cmdArgs[2]);
                double salary = double.Parse(cmdArgs[3]);

                try
                {
                    var person = new Person(firstName,
                                            lastName,
                                            age,
                                            salary);

                    myTeam.AddPlayer(person);
                    //persons.Add(person);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            Console.WriteLine(myTeam);

            //var bonus = double.Parse(Console.ReadLine());

            //foreach (var person in persons)
            //{
            //    person.IncreaseSalary(bonus);
            //}

            //persons.ForEach(p => Console.WriteLine(p.ToString()));
        }
    }
}
