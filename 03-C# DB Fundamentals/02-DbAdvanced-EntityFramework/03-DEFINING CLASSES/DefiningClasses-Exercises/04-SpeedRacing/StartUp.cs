using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_SpeedRacing
{
    class StartUp
    {
        static void Main()
        {
            Dictionary<string, Car> cars = new Dictionary<string, Car>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] args = Console.ReadLine().Split();

                string model = args[0];
                decimal fuelAmount = decimal.Parse(args[1]);
                decimal fuelConsumptoin = decimal.Parse(args[2]);

                if (!cars.ContainsKey(model))
                {
                    cars.Add(model, new Car(model, fuelAmount, fuelConsumptoin));
                }
            }

            string command;
            while ((command = Console.ReadLine()) != "End")
            {
                string[] cmndArgs = command.Split();
                
                if(cmndArgs[0] == "Drive")
                {
                    string model = cmndArgs[1];
                    decimal amountOfKm = decimal.Parse(cmndArgs[2]);

                    Car currentCar = cars.FirstOrDefault(c => c.Key == model).Value;

                    currentCar.MoveCar(amountOfKm);
                }
            }

            foreach (var car in cars)
            {
                Console.WriteLine(car.Value);
            }
        }
    }
}