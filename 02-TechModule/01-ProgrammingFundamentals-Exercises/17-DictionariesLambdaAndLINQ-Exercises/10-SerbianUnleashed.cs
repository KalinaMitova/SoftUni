using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _10_SerbianUnleashed
{
    class Program
    {
        static void Main(string[] args)
        {
            string pat = @"([\w ]+)\s@([\w ]+)\s(\w+)\s(\w+)";
            Regex r = new Regex(pat, RegexOptions.IgnoreCase);
            var venuesSingersMoneys = 
                new Dictionary<string, Dictionary<string, int>>();

            string line = Console.ReadLine();

            while (line != "End")
            {
                Match m = r.Match(line);

                if (m.Success)
                {
                    var singer = m.Groups[1].Value.Trim();
                    var venue = m.Groups[2].Value.Trim();
                    var ticketsPrice = int.Parse(m.Groups[3].Value.Trim());
                    var ticketsCount = int.Parse(m.Groups[4].Value.Trim());

                    if (!venuesSingersMoneys.ContainsKey(venue))
                    {
                        venuesSingersMoneys[venue] = new Dictionary<string, int>();
                    }

                    if (!venuesSingersMoneys[venue].ContainsKey(singer))
                    {
                        venuesSingersMoneys[venue][singer] = 0;
                    }

                    venuesSingersMoneys[venue][singer] += ticketsCount * ticketsPrice;
                }

                line = Console.ReadLine();
            }

            foreach (var venue in venuesSingersMoneys)
            {
                Console.WriteLine(venue.Key);

                var orderedSingers = venue.Value.OrderByDescending(kvp => kvp.Value);

                foreach (var singerMoneys in orderedSingers)
                {
                    var singer = singerMoneys.Key;
                    var moneys = singerMoneys.Value;

                    Console.WriteLine($"#  {singer} -> {moneys}");
                }
            }
        }
    }
}
