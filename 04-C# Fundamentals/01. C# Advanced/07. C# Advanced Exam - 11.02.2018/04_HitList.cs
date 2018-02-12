namespace _04_HitList
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        static void Main()
        {
            Dictionary<string, Dictionary<string, string>> people =
                new Dictionary<string, Dictionary<string, string>>();

            int targetInfoIndex = int.Parse(Console.ReadLine());

            string line;
            while ((line = Console.ReadLine()) != "end transmissions")
            {
                string[] tokens = line.Split(new char[] { '=' }, StringSplitOptions.RemoveEmptyEntries);
                string name = tokens[0];

                if (!people.ContainsKey(name))
                {
                    people.Add(name, new Dictionary<string, string>());
                }

                string[] info = tokens[1].Split(":;".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

                for (int i = 0; i < info.Length; i += 2)
                {
                    string key = info[i];
                    string value = info[i + 1];

                    if (!people[name].ContainsKey(key))
                    {
                        people[name].Add(key, value);
                    }
                    else
                    {
                        people[name][key] = value;
                    }
                }
            }

            string nameToKill = Console.ReadLine().Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)[1];

            if (people.ContainsKey(nameToKill))
            {
                Console.WriteLine($"Info on {nameToKill}:");

                foreach (var info in people[nameToKill].OrderBy(p => p.Key))
                {
                    Console.WriteLine($"---{info.Key}: {info.Value}");
                }

                int infoIndex = people[nameToKill].Sum(p => p.Key.Length + p.Value.Length);

                Console.WriteLine($"Info index: {infoIndex}");

                if(infoIndex >= targetInfoIndex)
                {
                    Console.WriteLine("Proceed");
                }
                else
                {
                    Console.WriteLine($"Need {targetInfoIndex - infoIndex} more info.");
                }
            }
        }
    }
}
