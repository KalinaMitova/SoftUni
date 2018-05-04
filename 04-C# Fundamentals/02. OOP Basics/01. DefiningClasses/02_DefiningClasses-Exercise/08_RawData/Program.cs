using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

public class Program
{
    public static void Main()
    {
        List<Car> cars = new List<Car>();

        int n = int.Parse(Console.ReadLine());

        // Read input
        for (int i = 0; i < n; i++)
        {
            string[] carInput = Console.ReadLine().Split();

            string model = carInput[0];

            int engineSpeed = int.Parse(carInput[1]);
            int enginePower = int.Parse(carInput[2]);
            Engine engine = new Engine(engineSpeed, enginePower);

            int cargoWeight = int.Parse(carInput[3]);
            string cargoType = carInput[4];
            Cargo cargo = new Cargo(cargoWeight, cargoType);

            List<Tire> tires = new List<Tire>(4);
            for (int j = 5; j <= 12; j+=2)
            {
                double tirePressure = double.Parse(carInput[j], CultureInfo.InvariantCulture);
                int tireAge = int.Parse(carInput[j + 1]);
                tires.Add(new Tire(tirePressure, tireAge));
            }

            Car car = new Car(model, engine, cargo, tires.ToArray());
            cars.Add(car);
        }

        string command = Console.ReadLine();

        if(command == "fragile")
        {
            Car[] filteredCars = cars
                .Where(c => c.Cargo.Type == command && c.Tires.Any(t => t.Pressure < 1)).ToArray();

            foreach (var car in filteredCars)
            {
                Console.WriteLine(car.Model);
            }
        }
        else if(command == "flamable")
        {
            Car[] filteredCars = cars
                .Where(c => c.Cargo.Type == command && c.Engine.Power > 250).ToArray();

            foreach (var car in filteredCars)
            {
                Console.WriteLine(car.Model);
            }
        }
    }
}