using System;
using System.Collections.Generic;
using System.Globalization;

public class Program
{
    public static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        Dictionary<string, Car> cars = new Dictionary<string, Car>(n);

        for (int i = 0; i < n; i++)
        {
            string[] tokens = Console.ReadLine().Split();

            string model = tokens[0];
            decimal fuelAmount = decimal.Parse(tokens[1], CultureInfo.InvariantCulture);
            decimal fuelConsumtion = decimal.Parse(tokens[2], CultureInfo.InvariantCulture);

            Car car = new Car(model, fuelAmount, fuelConsumtion);

            if (!cars.ContainsKey(model))
            {
                cars.Add(model, car);
            }
        }

        string command;
        while ((command = Console.ReadLine()) != "End")
        {
            string[] tokens = command.Split();

            string model = tokens[1];
            decimal distance = decimal.Parse(tokens[2], CultureInfo.InvariantCulture);

            if (cars.ContainsKey(model))
            {
                cars[model].Drive(distance);
            }
        }

        foreach (var car in cars)
        {
            Console.WriteLine($"{car.Value.Model} {car.Value.FuelAmount:F2} {car.Value.Distance}");
        }
    }
}