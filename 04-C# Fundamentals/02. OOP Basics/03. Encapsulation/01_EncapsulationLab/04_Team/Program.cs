using System;
using System.Collections.Generic;

public class Program
{        
    public static void Main()
    {
        Team team = new Team();

        var lines = int.Parse(Console.ReadLine());
        var persons = new List<Person>();
        for (int i = 0; i < lines; i++)
        {
            var cmdArgs = Console.ReadLine().Split();

            try
            {
                var person = new Person(cmdArgs[0],
                                    cmdArgs[1],
                                    int.Parse(cmdArgs[2]),
                                    decimal.Parse(cmdArgs[3]));

                persons.Add(person);
                team.AddPlayer(person);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        Console.WriteLine(team);
    }
}