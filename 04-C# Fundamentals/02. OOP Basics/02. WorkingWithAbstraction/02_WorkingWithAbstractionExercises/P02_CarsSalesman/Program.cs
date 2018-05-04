using System;
using System.Collections.Generic;
using System.Linq;

public class CarSalesman
{
    public static void Main(string[] args)
    {
        List<Car> cars = new List<Car>();
        List<Engine> engines = new List<Engine>();

        int engineCount = int.Parse(Console.ReadLine());

        ReadEngines(engines, engineCount);

        int carCount = int.Parse(Console.ReadLine());

        ReadCars(cars, engines, carCount);

        PrintCars(cars);
    }

    private static void ReadCars(List<Car> cars, List<Engine> engines, int carCount)
    {
        for (int i = 0; i < carCount; i++)
        {
            string[] parameters = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            Car car = CarParse(engines, parameters);

            cars.Add(car);
        }
    }

    private static void ReadEngines(List<Engine> engines, int engineCount)
    {
        for (int i = 0; i < engineCount; i++)
        {
            string[] parameters = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            Engine engine = EngineParse(parameters);

            engines.Add(engine);
        }
    }

    private static void PrintCars(List<Car> cars)
    {
        foreach (var car in cars)
        {
            Console.WriteLine(car);
        }
    }

    private static Car CarParse(List<Engine> engines, string[] parameters)
    {
        string model = parameters[0];
        string engineModel = parameters[1];

        Engine engine = engines.FirstOrDefault(x => x.Model == engineModel);

        int weight = -1;

        if (parameters.Length == 3 && int.TryParse(parameters[2], out weight))
        {
            return new Car(model, engine, weight);
        }
        else if (parameters.Length == 3)
        {
            string color = parameters[2];
            return new Car(model, engine, color);
        }
        else if (parameters.Length == 4)
        {
            string color = parameters[3];
            return new Car(model, engine, int.Parse(parameters[2]), color);
        }
        else
        {
            return new Car(model, engine);
        }
    }

    private static Engine EngineParse(string[] parameters)
    {
        string model = parameters[0];
        int power = int.Parse(parameters[1]);

        int displacement = -1;

        if (parameters.Length == 3 && int.TryParse(parameters[2], out displacement))
        {
            return new Engine(model, power, displacement);
        }
        else if (parameters.Length == 3)
        {
            string efficiency = parameters[2];
            return new Engine(model, power, efficiency);
        }
        else if (parameters.Length == 4)
        {
            string efficiency = parameters[3];
            return new Engine(model, power, int.Parse(parameters[2]), efficiency);
        }
        else
        {
            return new Engine(model, power);
        }
    }
}