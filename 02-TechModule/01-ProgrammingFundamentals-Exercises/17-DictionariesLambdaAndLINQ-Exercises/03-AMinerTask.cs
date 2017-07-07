using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_AMinerTask
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            var resources = new Dictionary<string, int>();
            int counter = 1;
            var resource = input;

            while (input != "stop")
            {
                if (counter % 2 == 0)
                {
                    var quantity = int.Parse(input);

                    if (resources.ContainsKey(resource))
                    {
                        resources[resource] += quantity;
                    }
                }
                else
                {
                    resource = input;

                    if (!resources.ContainsKey(resource))
                    {
                        resources.Add(resource, 0);
                    }
                }

                input = Console.ReadLine();
                counter++;
            }

            foreach (var recourse in resources)
            {
                Console.WriteLine($"{recourse.Key} -> {recourse.Value}");
            }
        }
    }
}