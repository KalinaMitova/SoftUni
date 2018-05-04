using System.Text;

public class Engine
{
    private const string offset = "  ";

    private string model;
    private int power;
    private int displacement;
    private string efficiency;
    
    public string Model
    {
        get { return model; }
        set { model = value; }
    }

    public int Power
    {
        get { return power; }
        set { power = value; }
    }
    
    public int Displacement
    {
        get { return displacement; }
        set { displacement = value; }
    }
    
    public string Efficiency
    {
        get { return efficiency; }
        set { efficiency = value; }
    }
    
    public Engine()
    {
        Displacement = -1;
        Efficiency = "n/a";
    }

    public Engine(string model, int power)
        : this()
    {
        Model = model;
        Power = power;
    }

    public Engine(string model, int power, int displacement)
        : this(model, power)
    {
        Displacement = displacement;
    }

    public Engine(string model, int power, string efficiency)
        : this(model, power)
    {
        Efficiency = efficiency;
    }

    public Engine(string model, int power, int displacement, string efficiency)
    {
        Model = model;
        Power = power;
        Displacement = displacement;
        Efficiency = efficiency;
    }
    
    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();

        sb.AppendFormat("{0}{1}:\n", offset, Model);
        sb.AppendFormat("{0}{0}Power: {1}\n", offset, Power);
        sb.AppendFormat("{0}{0}Displacement: {1}\n", offset, Displacement == -1 ? "n/a" : Displacement.ToString());
        sb.AppendFormat("{0}{0}Efficiency: {1}\n", offset, Efficiency);

        return sb.ToString();
    }
}