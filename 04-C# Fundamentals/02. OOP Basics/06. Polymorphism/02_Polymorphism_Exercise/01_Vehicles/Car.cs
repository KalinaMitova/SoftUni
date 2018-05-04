using System;

public class Car : Vehicle
{
    public override double SummerCostRate => 0.9;

    public Car(double fuelQuantity, double fuelConsumption)
        :base(fuelQuantity, fuelConsumption)
    { 
    }    
}