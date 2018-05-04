public class Ferrari : ICar
{
    public string Model => "488-Spider";

    public string DriverName { get; set; }

    public Ferrari(string driverName)
    {
        this.DriverName = driverName;
    }

    public string Brakes()
    {
        return "Brakes!";
    }

    public string Gas()
    {
        return "Zadu6avam sA!";
    }

    public override string ToString()
    {
        return $"{this.Model}/{this.Brakes()}/{this.Gas()}/{this.DriverName}";
    }
}