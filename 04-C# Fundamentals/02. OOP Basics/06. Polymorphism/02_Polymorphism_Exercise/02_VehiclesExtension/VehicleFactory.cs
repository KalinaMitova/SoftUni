using System;

public class VehicleFactory
{
    public Vehicle GetType(string[] vehicleInput)
    {
        string vehicleType = vehicleInput[0];
        double vehicleFuelQuantity = double.Parse(vehicleInput[1]);
        double vehicleFuelConsumtion = double.Parse(vehicleInput[2]);
        double vehicleTankCapacity = double.Parse(vehicleInput[3]);

        switch (vehicleType)
        {
            case "Car": return new Car(vehicleFuelQuantity, vehicleFuelConsumtion, vehicleTankCapacity);
            case "Truck": return new Truck(vehicleFuelQuantity, vehicleFuelConsumtion, vehicleTankCapacity);
            case "Bus": return new Bus(vehicleFuelQuantity, vehicleFuelConsumtion, vehicleTankCapacity);
            default: throw new ArgumentException();
        }
    }
}