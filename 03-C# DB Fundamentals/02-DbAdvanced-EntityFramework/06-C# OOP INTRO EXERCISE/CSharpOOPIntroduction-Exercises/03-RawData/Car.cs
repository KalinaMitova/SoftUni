using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_RawData
{
    class Car
    {
        private string model;
        private Engine engine;
        private Cargo cargo;
        private Tire[] tires;

        public Car(string model, 
            int engineSpeed, int enginePower, 
            int cargoWeight, string cargoType, 
            double tyre1Pressure, int tyre1Age,
            double tyre2Pressure, int tyre2Age, 
            double tyre3Pressure, int tyre3Age,
            double tyre4Pressure, int tyre4Age)
        {
            this.Model = model;
            this.Engine = new Engine(engineSpeed, enginePower);
            this.cargo = new Cargo(cargoWeight, cargoType);
            this.tires = new Tire[]
            {
                new Tire(tyre1Pressure, tyre1Age),
                new Tire(tyre2Pressure, tyre2Age),
                new Tire(tyre3Pressure, tyre3Age),
                new Tire(tyre4Pressure, tyre4Age),
            };
        }

        public string Model
        {
            get
            {
                return this.model;
            }
            set
            {
                this.model = value;
            }
        }
        public Engine Engine
        {
            get
            {
                return this.engine;
            }
            set
            {
                this.engine = value;
            }
        }
        public Cargo Cargo
        {
            get
            {
                return this.cargo;
            }
            set
            {
                this.cargo = value;
            }
        }
        public Tire[] Tires
        {
            get
            {
                return this.tires;
            }
            set
            {
                this.tires = value;
            }
        }
    }
}
