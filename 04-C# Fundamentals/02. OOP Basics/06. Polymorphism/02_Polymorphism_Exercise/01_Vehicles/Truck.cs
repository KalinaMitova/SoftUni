using System;

public class Truck : Vehicle
{
    public override double SummerCostRate => 1.6;

    public Truck(double fuelQuantity, double fuelConsumption)
        : base(fuelQuantity, fuelConsumption)
    {
    }

    public override void Refuel(double fuel)
    {
        this.FuelQuantity += fuel * 0.95;
    }
}