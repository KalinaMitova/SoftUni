public class Engine
{
    private string model;
    private double power;
    private string displacement;
    private string effiecency;

    public string Model
    {
        get { return model; }
        set { model = value; }
    }

    public double Power
    {
        get { return power; }
        set { power = value; }
    }

    public string Displacement
    {
        get { return displacement; }
        set { displacement = value; }
    }


    public string Efficiency
    {
        get { return effiecency; }
        set { effiecency = value; }
    }

    public Engine(string model, double power)
    {
        this.Model = model;
        this.Power = power;
        this.Displacement = "n/a";
        this.Efficiency = "n/a";
    }    
}