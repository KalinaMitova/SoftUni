using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_RawData
{
    class StartUp
    {
        static void Main()
        {
            List<Car> cars = new List<Car>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] args = Console.ReadLine().Split();
                string model = args[0];
                int engineSpeed = int.Parse(args[1]);
                int enginePower = int.Parse(args[2]);
                int cargoWeight = int.Parse(args[3]);
                string cargoType = args[4];
                double tyre1Pressure = double.Parse(args[5]);
                int tyre1Age = int.Parse(args[6]);
                double tyre2Pressure = double.Parse(args[7]);
                int tyre2Age = int.Parse(args[8]);
                double tyre3Pressure = double.Parse(args[9]);
                int tyre3Age = int.Parse(args[10]);
                double tyre4Pressure = double.Parse(args[11]);
                int tyre4Age = int.Parse(args[12]);

                cars.Add(new Car(model, 
                    engineSpeed, enginePower, 
                    cargoWeight, cargoType,
                    tyre1Pressure, tyre1Age,
                    tyre2Pressure, tyre2Age,
                    tyre3Pressure, tyre3Age,
                    tyre4Pressure, tyre4Age));
            }

            var cargoTypeToPrint = Console.ReadLine();

            if (cargoTypeToPrint == "fragile")
            {
                var frigleCargoType = cars.Where(c => c.Cargo.Type == cargoTypeToPrint && c.Tires.Any(t => t.Pressure < 1));

                foreach (var car in frigleCargoType)
                {
                    Console.WriteLine(car.Model);
                }
            }
            else if(cargoTypeToPrint == "flammable")
            {
                var flammableCargoType = cars.Where(c => c.Cargo.Type == cargoTypeToPrint && c.Engine.Power > 250);

                foreach (var car in flammableCargoType)
                {
                    Console.WriteLine(car.Model);
                }
            }
        }
    }
}
