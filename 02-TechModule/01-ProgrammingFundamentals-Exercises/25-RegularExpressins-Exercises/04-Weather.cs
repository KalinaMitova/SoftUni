using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _04_Weather
{
    class Program
    {
        static void Main(string[] args)
        {
            var towns = new List<Town>();

            var pattern = @"(?<town>[A-Z]{2})(?<temp>\d+\.\d+)(?<weather>[A-z]+)\|";

            string line = Console.ReadLine();

            while (line != "end")
            {
                var townTempWeather = Regex.Match(line, pattern);

                if (townTempWeather.Success)
                {
                    string town = townTempWeather.Groups["town"].Value;
                    string temp = townTempWeather.Groups["temp"].Value;
                    string weather = townTempWeather.Groups["weather"].Value;

                    Town currentTown = new Town
                    {
                        Name = town,
                        Temperature = decimal.Parse(temp),
                        TypeOfWeather = weather
                    };

                    if (towns.Any(t => t.Name == town))
                    {
                        var townToRemove = towns.Find(t => t.Name == town);
                        towns.Remove(townToRemove);
                    }
                    towns.Add(currentTown);
                }               
                
                line = Console.ReadLine();
            }

            foreach (var town in towns.OrderBy(t => t.Temperature))
            {
                Console.WriteLine(town);
            }
        }
    }
    class Town
    {
        public string Name { get; set; }

        public decimal Temperature { get; set; }

        public string TypeOfWeather { get; set; }

        public override string ToString()
        {
            return $"{Name} => {Temperature:F2} => {TypeOfWeather}";
        }
    }
}
