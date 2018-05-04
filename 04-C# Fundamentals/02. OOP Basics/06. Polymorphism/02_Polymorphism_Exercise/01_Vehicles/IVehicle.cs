public interface IVehicle
{
    double FuelQuantity { get; }
    double FuelConsumption { get; }
    double Distance { get; }

    void Drive(double distance);
    void Refuel(double liters);
}