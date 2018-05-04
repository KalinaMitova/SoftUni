using System;

public class Truck : Vehicle
{
    public Truck(double fuelQuantity, double fuelConsumption, double tankCapacity)
        : base(fuelQuantity, fuelConsumption, tankCapacity)
    {
    }

    public override double AirConditionerConsumption => 1.6;

    public override void Refuel(double fuel)
    {
        if (fuel <= 0)
        {
            throw new ArgumentException(InvalidFuelMessage);
        }

        if (this.FuelQuantity + (fuel * 0.95) > this.TankCapacity)
        {
            throw new ArgumentException(string.Format(InvalidFuelAmountMessage, fuel));
        }

        this.FuelQuantity += (fuel * 0.95);
    }
}