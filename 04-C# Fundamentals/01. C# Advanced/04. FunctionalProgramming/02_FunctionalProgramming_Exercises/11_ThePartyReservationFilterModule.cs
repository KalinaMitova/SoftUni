namespace _11_ThePartyReservationFilterModule
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    public class ThePartyReservationFilterModule
    {
        public static void Main()
        {
            List<string> people = Console.ReadLine()
                .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            Dictionary<string, List<string>> filterTypeParameter = new Dictionary<string, List<string>>();

            string input;
            while ((input = Console.ReadLine()) != "Print")
            {
                string[] tokens = input
                    .Split(new string[] { ";" }, StringSplitOptions.RemoveEmptyEntries);

                string command = tokens[0];
                string filterType = tokens[1];
                string filterParameter = tokens[2];

                if(command == "Add filter")
                {
                    if (!filterTypeParameter.ContainsKey(filterType))
                    {
                        filterTypeParameter.Add(filterType, new List<string>());
                    }
                    filterTypeParameter[filterType].Add(filterParameter);
                }
                else if (command == "Remove filter")
                {
                    filterTypeParameter[filterType].Remove(filterParameter);
                }
            }

            foreach (var f in filterTypeParameter)
            {
                foreach (var parameter in f.Value)
                {
                    var filter = CreateFilter(f.Key, parameter);
                    people.RemoveAll(filter);
                }
            }

            Console.WriteLine(string.Join(" ", people));
        }

        private static Predicate<string> CreateFilter(string type, string parameter)
        {
            switch (type)
            {
                case "Starts with":
                    return x => x.StartsWith(parameter);
                case "Ends with":
                    return x => x.EndsWith(parameter);
                case "Contains":
                    return x => x.Contains(parameter);
                case "Length":
                    return x => x.Length == int.Parse(parameter);
                default:
                    throw new ArgumentException();
            }
        }
    }
}
