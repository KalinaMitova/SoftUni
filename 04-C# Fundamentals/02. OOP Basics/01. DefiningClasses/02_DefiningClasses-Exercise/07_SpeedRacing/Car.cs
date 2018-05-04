public class Car
{
    private string model;
    private decimal fuelAmount;
    private decimal fuelConsumption;
    private decimal distance;

    public string Model
    {
        get { return model; }
        set { model = value; }
    }
    
    public decimal FuelAmount
    {
        get { return fuelAmount; }
        set { fuelAmount = value; }
    }
    
    public decimal FuelConsumption
    {
        get { return fuelConsumption; }
        set { fuelConsumption = value; }
    }

    public decimal Distance
    {
        get { return distance; }
        set { distance = value; }
    }

    public Car(string model, decimal fuelAmount, decimal fuelConsumption)
    {
        this.Model = model;
        this.FuelAmount = fuelAmount;
        this.FuelConsumption = fuelConsumption;
        this.Distance = 0;
    }

    public void Drive(decimal distance)
    {
        decimal neededFuel = distance * this.FuelConsumption;

        if(neededFuel <= this.FuelAmount)
        {
            this.FuelAmount -= neededFuel;
            this.Distance += distance;
        }
        else
        {
            System.Console.WriteLine($"Insufficient fuel for the drive");
        }
    }
}