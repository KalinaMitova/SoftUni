public abstract class Driver
{
    private string name;
    private double totalTime;
    private Car car;
    private string failureMessage;
    private bool isCrashed;

    protected Driver(string name, Car car)
    {
        this.Name = name;
        this.TotalTime = 0;
        this.Car = car;
        this.IsCrashed = false;
    }

    public string Name
    {
        get { return name; }
        private set { name = value; }
    }

    public double TotalTime
    {
        get { return totalTime; }
        set { totalTime = value; }
    }

    public Car Car
    {
        get { return car; }
        private set { car = value; }
    }
    
    public bool IsCrashed
    {
        get { return isCrashed; }
        set { isCrashed = value; }
    }
    
    public string FailureMessage
    {
        get { return failureMessage; }
        set { failureMessage = value; }
    }
    
    public abstract double FuelConsumptionPerKm { get; }

    public virtual double Speed => (this.Car.Hp + this.Car.Tyre.Degradation) / this.Car.FuelAmount;
}