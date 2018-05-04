using System;
using System.Collections.Generic;

namespace _10_ExplicitInterfaces
{
    public class Program
    {
        public static void Main()
        {
            List<Citizen> citizens = new List<Citizen>();

            string input;
            while ((input = Console.ReadLine()) != "End")
            {
                string[] tokens = input.Split();

                string name = tokens[0];
                string country = tokens[1];
                int age = int.Parse(tokens[2]);

                Citizen citizen = new Citizen(name, country, age);

                citizens.Add(citizen);
            }

            foreach (var citizen in citizens)
            {
                IPerson person = (IPerson)citizen;
                IResident resident = (IResident)citizen;

                Console.WriteLine(person.GetName());
                Console.WriteLine(resident.GetName());
            }
        }
    }
}
