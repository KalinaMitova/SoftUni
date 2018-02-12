namespace _10_PredicateParty
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    public class PredicateParty
    {
        public static void Main()
        {
            List<string> people = Console.ReadLine()
                .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .ToList();
            
            string input;
            while ((input = Console.ReadLine()) != "Party!")
            {
                string[] tokens = input
                    .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);

                string command = tokens[0];
                string inputCondition = tokens[1];
                string conditionArgs = tokens[2];

                Func<string, bool> condition = CreateCondition(inputCondition, conditionArgs);
                
                switch (command)
                {
                    case "Remove":
                        people = people.Where(x => !condition(x)).ToList();
                        break;
                    case "Double":
                        for (int i = 0; i < people.Count(); i++)
                        {
                            if (condition(people[i]))
                            {
                                people.Insert(i, people[i]);
                                i++;
                            }
                        }
                        break;
                    default:
                        throw new ArgumentException();
                }
            }

            if (people.Count() == 0)
            {
                Console.WriteLine("Nobody is going to the party!");
            }
            else
            {
                Console.WriteLine(string.Join(", ", people) + " are going to the party!");
            }
        }
        
        private static Func<string, bool> CreateCondition(string input, string args)
        {
            switch (input)
            {
                case "StartsWith":
                    return x => x.StartsWith(args);
                case "EndsWith":
                    return x => x.EndsWith(args);
                case "Length":
                    return x => x.Length == int.Parse(args);
                default:
                    throw new InvalidOperationException();
            }
        }
    }
}
