using System;
using System.Collections.Generic;
using System.Linq;
  
class RawData
{
    static void Main(string[] args)
    {
        List<Car> cars = new List<Car>();

        int carsCount = int.Parse(Console.ReadLine());

        ReadCars(cars, carsCount);

        string cargoType = Console.ReadLine();

        List<string> carModelsByCargoType = GetCarsByCargoType(cars, cargoType);

        PrintCarModels(carModelsByCargoType);
    }

    private static void ReadCars(List<Car> cars, int lines)
    {
        for (int i = 0; i < lines; i++)
        {
            string[] parameters = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            Car car = CreateCar(parameters);

            cars.Add(car);
        }
    }

    private static void PrintCarModels(List<string> carModelsByCargoType)
    {
        Console.WriteLine(string.Join(Environment.NewLine, carModelsByCargoType));
    }

    private static List<string> GetCarsByCargoType(List<Car> cars, string cargoType)
    {
        IEnumerable<Car> carModelsByCargoType = cars;

        if (cargoType == "fragile")
        {
            carModelsByCargoType = carModelsByCargoType.Where(c => c.CargoType == "fragile" && c.Tires.Any(t => t.Pressure < 1));                    
        }
        else
        {
            carModelsByCargoType = carModelsByCargoType.Where(c => c.CargoType == "flamable" && c.EnginePower > 250);
        }

        List<string> filteredCars = carModelsByCargoType
            .Select(c => c.Model)
            .ToList();

        return filteredCars;            
    }

    private static Car CreateCar(string[] parameters)
    {
        string model = parameters[0];

        int engineSpeed = int.Parse(parameters[1]);
        int enginePower = int.Parse(parameters[2]);

        int cargoWeight = int.Parse(parameters[3]);
        string cargoType = parameters[4];

        List<Tire> tires = new List<Tire>(4);

        for (int j = 5; j < parameters.Length; j += 2)
        {
            double tirePressure = double.Parse(parameters[j]);
            int tireAge = int.Parse(parameters[j + 1]);

            Tire tire = new Tire(tirePressure, tireAge);
            tires.Add(tire);
        }

        Car car = new Car(model, engineSpeed, enginePower, cargoWeight, cargoType, tires);

        return car;
    }
}