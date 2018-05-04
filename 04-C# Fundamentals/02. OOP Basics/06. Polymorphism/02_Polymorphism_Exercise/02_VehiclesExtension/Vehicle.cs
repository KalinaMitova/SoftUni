using System;

public abstract class Vehicle : IVehicle
{
    protected const string SuccessfulMovementMessage = "{0} travelled {1} km";
    protected const string UnsuccessfulMovementMessage = "{0} needs refueling";
    protected const string InvalidFuelMessage = "Fuel must be a positive number";
    protected const string InvalidFuelAmountMessage = "Cannot fit {0} fuel in the tank";
    
    public Vehicle(double fuelQuantity, double fuelConsumption, double tankCapacity)
    {
        if(fuelQuantity > tankCapacity)
        {
            this.FuelQuantity = 0;
        }
        else
        {
            this.FuelQuantity = fuelQuantity;
        }

        this.TankCapacity = tankCapacity;
        this.FuelConsumption = fuelConsumption;
    }

    public abstract double AirConditionerConsumption { get; }
        
    public double FuelQuantity { get; set; }

    public double FuelConsumption { get; set; }
    
    public double TankCapacity { get; set; }

    public string Drive(double distance)
    {
        double neededFuel = distance * (this.FuelConsumption + this.AirConditionerConsumption);

        if (neededFuel <= this.FuelQuantity)
        {
            this.FuelQuantity -= neededFuel;
            return string.Format(SuccessfulMovementMessage, this.GetType().Name, distance);
        }

        return string.Format(UnsuccessfulMovementMessage, this.GetType().Name);        
    }
    
    public virtual void Refuel(double fuel)
    {
        if (fuel <= 0)
        {
            throw new ArgumentException(InvalidFuelMessage);
        }

        if (this.FuelQuantity + fuel > this.TankCapacity)
        {
            throw new ArgumentException(string.Format(InvalidFuelAmountMessage, fuel));
        }

        this.FuelQuantity += fuel;
    }
    
    public override string ToString()
    {
        string result = $"{this.GetType().Name}: {this.FuelQuantity:F2}";
        return result;
    }
}