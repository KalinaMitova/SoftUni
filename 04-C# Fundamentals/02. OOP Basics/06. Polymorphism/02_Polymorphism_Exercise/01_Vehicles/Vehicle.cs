using System;

public abstract class Vehicle : IVehicle
{
    private const string SuccessfulMovementMessage = "{0} travelled {1} km";
    private const string UnsuccessfulMovementMessage = "{0} needs refueling";

    public Vehicle(double fuelQuantity, double fuelConsumption)
    {
        this.FuelQuantity = fuelQuantity;
        this.FuelConsumption = fuelConsumption + this.SummerCostRate;
        this.Distance = 0;
    }

    public abstract double SummerCostRate { get; }

    public double FuelQuantity { get; set; }

    public double FuelConsumption { get; set; }

    public double Distance { get; set; }

    public void Drive(double distanceToTravel)
    {
        double neededFuel = distanceToTravel * this.FuelConsumption;
        if (neededFuel <= FuelQuantity)
        {
            this.Distance += distanceToTravel;
            this.FuelQuantity -= neededFuel;
            Console.WriteLine(SuccessfulMovementMessage, this.GetType().Name, distanceToTravel);
        }
        else
        {
            Console.WriteLine(UnsuccessfulMovementMessage, this.GetType().Name);
        }
    }

    public virtual void Refuel(double fuel)
    {
        this.FuelQuantity += fuel;
    }

    public override string ToString()
    {
        string result = $"{this.GetType().Name}: { this.FuelQuantity:F2}";
        return result;
    }
}