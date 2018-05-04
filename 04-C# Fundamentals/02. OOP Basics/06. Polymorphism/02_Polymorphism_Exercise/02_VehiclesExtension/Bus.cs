using System;

public class Bus : Vehicle
{
    public Bus(double fuelQuantity, double fuelConsumption, double tankCapacity) 
        : base(fuelQuantity, fuelConsumption, tankCapacity)
    {

    }

    public override double AirConditionerConsumption => 1.4;

    public string DriveEmpty(double distanceToTravel)
    {
        double neededFuel = distanceToTravel * this.FuelConsumption;
        
        if (neededFuel <= this.FuelQuantity)
        {
            this.FuelQuantity -= neededFuel;
            return string.Format(SuccessfulMovementMessage, this.GetType().Name, distanceToTravel);
        }
        else
        {
            return string.Format(UnsuccessfulMovementMessage, this.GetType().Name);
        }
    }
}