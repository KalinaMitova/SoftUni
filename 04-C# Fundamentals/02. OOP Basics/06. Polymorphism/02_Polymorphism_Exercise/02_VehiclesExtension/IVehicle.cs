public interface IVehicle
{
    double FuelQuantity { get; }
    double FuelConsumption { get; }
    double TankCapacity { get; }
    double AirConditionerConsumption { get; }

    string Drive(double distance);
    void Refuel(double liters);
}