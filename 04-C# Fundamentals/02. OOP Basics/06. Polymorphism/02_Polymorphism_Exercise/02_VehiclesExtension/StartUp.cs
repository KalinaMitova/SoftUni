using System;
using System.Collections.Generic;

namespace _01_Vehicles
{
    public class Startup
    {
        public static void Main()
        {
            List<Vehicle> vehicles = new List<Vehicle>();
            VehicleFactory vehicleFactory = new VehicleFactory();
            
            for (int i = 0; i < 3; i++)
            {
                string[] vehicleInput = Console.ReadLine().Split();
                
                Vehicle vehicle = vehicleFactory.GetType(vehicleInput);
                vehicles.Add(vehicle);
            }

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] tokens = Console.ReadLine().Split();

                string command = tokens[0];
                string vehicleType = tokens[1];

                try
                {
                    var vehicle = GetVehicle(vehicleType, vehicles);

                    switch (command)
                    {
                        case "Drive":
                            {
                                double distance = double.Parse(tokens[2]);
                                var driveResult = vehicle.Drive(distance);
                                Console.WriteLine(driveResult); 
                            }
                            break;
                        case "Refuel":
                            {
                                double fuel = double.Parse(tokens[2]);
                                vehicle.Refuel(fuel);
                            }
                            break;
                        case "DriveEmpty":
                            {
                                double distance = double.Parse(tokens[2]);                                
                                var driveResult = ((Bus)vehicle).DriveEmpty(distance);
                                Console.WriteLine(driveResult);
                            }
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }                
            }

            foreach (var vehicle in vehicles)
            {
                Console.WriteLine(vehicle);
            }
        }

        private static Vehicle GetVehicle(string vehicleType, List<Vehicle> vehicles)
        {
            if (vehicleType == "Car")
            {
                return vehicles[0];
            }
            else if (vehicleType == "Truck")
            {
                return vehicles[1];
            }
            else if (vehicleType == "Bus")
            {
                return vehicles[2];
            }

            throw new ArgumentException();
        }
    }
}
