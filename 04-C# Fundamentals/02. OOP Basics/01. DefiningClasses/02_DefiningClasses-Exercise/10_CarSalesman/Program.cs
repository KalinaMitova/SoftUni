using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    public static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        List<Engine> engines = new List<Engine>(n);

        for (int i = 0; i < n; i++)
        {
            string[] tokens = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);

            string model = tokens[0];
            double power = double.Parse(tokens[1]);

            Engine engine = new Engine(model, power);
            
            if (tokens.Length == 4)
            {
                double displacement = double.Parse(tokens[2]);
                string efficency = tokens[3];

                engine.Displacement = tokens[2];
                engine.Efficiency = efficency;
            }
            else if(tokens.Length == 3)
            {
                double displacement;
                bool isDisplacement = double.TryParse(tokens[2], out displacement);

                if (isDisplacement)
                {
                    engine.Displacement = tokens[2];
                }
                else
                {
                    engine.Efficiency = tokens[2];
                }
            }

            engines.Add(engine);
        }

        int m = int.Parse(Console.ReadLine());

        List<Car> cars = new List<Car>(m);

        for (int i = 0; i < m; i++)
        {
            string[] tokens = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);

            string model = tokens[0];
            Engine engine = engines.Single(e => e.Model == tokens[1]);

            Car car = new Car(model, engine);

            if(tokens.Length == 4)
            {
                car.Weight = tokens[2];
                car.Color = tokens[3];
            }
            else if(tokens.Length == 3)
            {
                double weight;
                bool isWeight = double.TryParse(tokens[2], out weight);

                if (isWeight)
                {
                    car.Weight = tokens[2];
                }
                else
                {
                    car.Color = tokens[2];
                }
            }

            cars.Add(car);
        }

        foreach (Car car in cars)
        {
            Console.WriteLine(car);
        }
    }
}