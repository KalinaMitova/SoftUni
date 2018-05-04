﻿using System;

public class Car : Vehicle
{
    public Car(double fuelQuantity, double fuelConsumption, double tankCapacity)
        :base(fuelQuantity, fuelConsumption, tankCapacity)
    {
    }

    public override double AirConditionerConsumption => 0.9;
}