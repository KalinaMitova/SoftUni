using System;

namespace _01_Vehicles
{
    public class Startup
    {
        public static void Main()
        {
            string[] carInput = Console.ReadLine().Split();
            string[] truckInput = Console.ReadLine().Split();

            double carFuelQuantity = double.Parse(carInput[1]);
            double carFuelConsumtion = double.Parse(carInput[2]);
            Vehicle car = new Car(carFuelQuantity, carFuelConsumtion);
            
            double truckFuelQuantity = double.Parse(truckInput[1]);
            double truckFuelConsumtion = double.Parse(truckInput[2]);
            Vehicle truck = new Truck(truckFuelQuantity, truckFuelConsumtion);

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] tokens = Console.ReadLine().Split();

                string command = tokens[0];
                string vehicleType = tokens[1];

                switch (command)
                {
                    case "Drive":
                        double distance = double.Parse(tokens[2]);
                        if (vehicleType == "Car")
                        {
                            car.Drive(distance);
                        }
                        else if (vehicleType == "Truck")
                        {
                            truck.Drive(distance);
                        }
                        break;
                    case "Refuel":
                        double fuel = double.Parse(tokens[2]);
                        if (vehicleType == "Car")
                        {
                            car.Refuel(fuel);
                        }
                        else if (vehicleType == "Truck")
                        {
                            truck.Refuel(fuel);
                        }
                        break;
                }
            }

            Console.WriteLine(car);
            Console.WriteLine(truck);
        }
    }
}
