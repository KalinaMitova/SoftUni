using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08_LogsAggregator
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            var namesIpsDurations = new SortedDictionary<string, SortedDictionary<string, decimal>>();

            for (int i = 0; i < n; i++)
            {
                string[] tokens = Console.ReadLine().Split();

                var name = tokens[1];
                var ip = tokens[0];
                var duration = decimal.Parse(tokens[2]);

                if (!namesIpsDurations.ContainsKey(name))
                {
                    namesIpsDurations[name] = new SortedDictionary<string, decimal>();
                }

                if (!namesIpsDurations[name].ContainsKey(ip))
                {
                    namesIpsDurations[name][ip] = 0;
                }

                namesIpsDurations[name][ip] += duration;
            }

            foreach (var nameIpsDurations in namesIpsDurations)
            {
                var name = nameIpsDurations.Key;
                var totalDuration = nameIpsDurations.Value.Values.Sum();
                var ips = string.Join(", ", nameIpsDurations.Value.Keys);
                Console.WriteLine($"{name}: {totalDuration} [{ips}]");
            }
        }
    }
}
