using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_SpeedRacing
{
    class Car
    {
        public string Model { get; set; }

        public decimal FuelAmount { get; set; }

        public decimal FuelConsumptionFor1km { get; set; }

        public decimal DistanceTaveled { get; set; }

        public Car()
        {
            this.DistanceTaveled = 0;
        }

        public Car(string model, decimal fuelAmount, decimal fuelConsumptionFor1Km)
            :this()
        {
            this.Model = model;
            this.FuelAmount = fuelAmount;
            this.FuelConsumptionFor1km = fuelConsumptionFor1Km;
        }

        public void MoveCar(decimal amountOfKm)
        {
            decimal neededFuel = amountOfKm * this.FuelConsumptionFor1km;

            if (neededFuel <= FuelAmount)
            {
                this.DistanceTaveled += amountOfKm;
                this.FuelAmount -= neededFuel;
            }
            else
            {
                Console.WriteLine("Insufficient fuel for the drive");
            }
        }

        public override string ToString()
        {
            return $"{this.Model} {this.FuelAmount:f2} {this.DistanceTaveled}";
        }
    }
}
