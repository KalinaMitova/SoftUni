using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07_PopulationCounter
{
    class Program
    {
        static void Main(string[] args)
        {
            var line = Console.ReadLine();

            var countriesCitiesPopulations =
                new Dictionary<string, Dictionary<string, decimal>>();

            while (line != "report")
            {
                var tokens = line.Split('|');

                var country = tokens[1];
                var city = tokens[0];
                var population = decimal.Parse(tokens[2]);
                
                if (!countriesCitiesPopulations.ContainsKey(country))
                {
                    countriesCitiesPopulations[country] = new Dictionary<string, decimal>();
                }

                if (!countriesCitiesPopulations[country].ContainsKey(city))
                {
                    countriesCitiesPopulations[country][city] = 0;
                }

                countriesCitiesPopulations[country][city] += population;

                line = Console.ReadLine();
            }

            var orderedCountries = countriesCitiesPopulations
                .OrderByDescending(kvp => kvp.Value.Values.Sum())
                .ToDictionary(x => x.Key, x => x.Value);

            foreach (var countryCitiesPopulations in orderedCountries)
            {
                var country = countryCitiesPopulations.Key;
                var citiesPopulations = countryCitiesPopulations.Value
                    .OrderByDescending(kvp => kvp.Value)
                    .ToDictionary(x => x.Key, x => x.Value);
                var totalPopulation = citiesPopulations.Values.Sum();

                Console.WriteLine($"{country} (total population: {totalPopulation})");

                foreach (var cityPopulation in citiesPopulations)
                {
                    var city = cityPopulation.Key;
                    var population = cityPopulation.Value;

                    Console.WriteLine($"=>{city}: {population}");
                }
            }
        }
    }
}
