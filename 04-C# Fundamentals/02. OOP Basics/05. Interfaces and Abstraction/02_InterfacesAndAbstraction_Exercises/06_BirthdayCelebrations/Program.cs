using System;
using System.Collections.Generic;
using System.Linq;

namespace _06_BirthdayCelebrations
{
    public class Program
    {
        public static void Main()
        {
            List<IBirthable> citizens = new List<IBirthable>();

            string input;
            while ((input = Console.ReadLine()) != "End")
            {
                string[] tokens = input.Split();

                string being = tokens[0];

                if (being == "Citizen")
                {
                    string name = tokens[1];
                    int age = int.Parse(tokens[2]);
                    string id = tokens[3];
                    string birthdate = tokens[4];

                    Citizen citizen = new Citizen(name, age, id, birthdate);

                    citizens.Add(citizen);
                }
                //else if (being == "Robot")
                //{
                //    string model = tokens[1];
                //    string id = tokens[2];

                //    Robot robot = new Robot(model, id);

                //    citizens.Add(robot);
                //}
                else if(being == "Pet")
                {
                    string name = tokens[1];
                    string birthdate = tokens[2];

                    Pet pet = new Pet(name, birthdate);

                    citizens.Add(pet);
                }
            }

            string specificYear = Console.ReadLine();

            List<IBirthable> filteredCitizens = citizens
                .Where(c => c.Birthdate.EndsWith(specificYear))
                .ToList();

            foreach (var c in filteredCitizens)
            {
                Console.WriteLine(c.Birthdate);
            }
        }
    }
}
