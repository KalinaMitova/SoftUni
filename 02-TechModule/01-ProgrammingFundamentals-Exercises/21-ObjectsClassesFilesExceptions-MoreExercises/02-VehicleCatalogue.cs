using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_VehicleCatalogue
{
    class Program
    {
        static void Main(string[] args)
        {
            var vehicles = ReadVehicles();

            PrintVehicles(vehicles);
        }

        private static void PrintVehicles(List<Vehicle> vehicles)
        {
            var line = Console.ReadLine();

            while (line != "Close the Catalogue")
            {
                var currentVehicle = vehicles.Find(v => v.Model == line);

                Console.WriteLine($"Type: {currentVehicle.Type}");
                Console.WriteLine($"Model: {currentVehicle.Model}");
                Console.WriteLine($"Color: {currentVehicle.Color}");
                Console.WriteLine($"Horsepower: {currentVehicle.Horsepower}");
                
                line = Console.ReadLine();
            }

            var cars = vehicles.Where(v => v.Type == "Car").ToList();

            var trucks = vehicles.Where(v => v.Type == "Truck").ToList();

            var carsHorsepowerAverage = 0.0;
            var trucksHorsepowerAverage = 0.0;

            if (cars.Count > 0)
            {
                carsHorsepowerAverage = cars.Average(c => c.Horsepower);
            }

            if (trucks.Count > 0)
            {
                trucksHorsepowerAverage = trucks.Average(t => t.Horsepower);
            }

            Console.WriteLine($"Cars have average horsepower of: {carsHorsepowerAverage:F2}.");
            Console.WriteLine($"Trucks have average horsepower of: {trucksHorsepowerAverage:F2}.");
        }

        private static List<Vehicle> ReadVehicles()
        {
            var vehicles = new List<Vehicle>();

            var line = Console.ReadLine();

            while (line != "End")
            {
                var tokens = line.Split();
                var type = tokens[0].ToLower();
                var model = tokens[1];
                var color = tokens[2];
                var horsepower = int.Parse(tokens[3]);

                if (type == "car")
                {
                    type = "Car";
                }
                if (type == "truck")
                {
                    type = "Truck";
                }

                var vehicle = new Vehicle
                {
                    Type = type,
                    Model = model,
                    Color = color,
                    Horsepower = horsepower
                };

                vehicles.Add(vehicle);

                line = Console.ReadLine();
            }

            return vehicles;
        }
    }

    class Vehicle
    {
        public string Type { get; set; }

        public string Model { get; set; }

        public string Color { get; set; }

        public int Horsepower { get; set; }
    }
}
