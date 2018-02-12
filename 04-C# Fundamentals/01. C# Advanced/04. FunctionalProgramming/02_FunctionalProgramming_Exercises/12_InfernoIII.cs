namespace _12_InfernoIII
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Inferno
    {
        public static void Main()
        {
            List<int> gems = Console.ReadLine()
                .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            Dictionary<string, List<int>> filterTypeParameter = new Dictionary<string, List<int>>();

            string input;
            while ((input = Console.ReadLine()) != "Forge")
            {
                string[] tokens = input
                    .Split(new string[] { ";" }, StringSplitOptions.RemoveEmptyEntries);

                string command = tokens[0];
                string filterType = tokens[1];
                int filterParameter = int.Parse(tokens[2]);

                if (command == "Exclude")
                {
                    if (!filterTypeParameter.ContainsKey(filterType))
                    {
                        filterTypeParameter[filterType] = new List<int>();
                    }
                    filterTypeParameter[filterType].Add(filterParameter);
                }
                else if (command == "Reverse")
                {
                    filterTypeParameter[filterType].Remove(filterParameter);
                }
            }

            List<int> gemsLeft = new List<int>(gems);
            
            foreach (var f in filterTypeParameter)
            {
                foreach (var parameter in f.Value)
                {
                    var filter = CreateFilter(gems, f.Key, parameter);

                    gemsLeft.RemoveAll(p => gems.Where(filter).Any(n => n == p));
                }
            }

            Console.WriteLine(string.Join(" ", gemsLeft));
        }

        private static Func<int, int, bool> CreateFilter(List<int> people, string filterType, int number)
        {
            switch (filterType)
            {
                case "Sum Left":
                    return (n, i) => n + (i - 1 < 0 ? 0 : people.ElementAt(i - 1)) == number;
                case "Sum Right":
                    return (n, i) => (n + (i + 1 >= people.Count() ? 0 : people.ElementAt(i + 1))) == number;
                case "Sum Left Right":
                    return (n, i) => (n + (i - 1 < 0 ? 0 : people.ElementAt(i - 1) + (i + 1 >= people.Count() ? 0 : people.ElementAt(i + 1)))) == number;
                default:
                    throw new ArgumentException();
            }
        }
    }
}
