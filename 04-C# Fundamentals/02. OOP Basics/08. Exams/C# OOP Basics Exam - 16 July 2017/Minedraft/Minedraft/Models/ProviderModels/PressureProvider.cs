using System.Text;

public class PressureProvider : Provider
{
    public PressureProvider(string id, double energyOutput) 
        : base(id, energyOutput)
    {
        this.EnergyOutput *= 1.5;
    }

    public override string ToString()
    {
        return "Pressure " + base.ToString();
    }
}