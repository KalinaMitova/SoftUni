using System;
using System.Text;

public abstract class Provider : MainId
{
    private double energyOutput;

    protected Provider(string id, double energyOutput)
        :base(id)
    {
        this.EnergyOutput = energyOutput;
    }
    
    public double EnergyOutput
    {
        get { return energyOutput; }
        protected set
        {
            if(value <= 0 || value > 10000)
            {
                throw new ArgumentException(nameof(EnergyOutput));
            }
            energyOutput = value;
        }
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();

        sb.AppendLine($"Provider - {this.Id}");
        sb.AppendLine($"Energy Output: {this.EnergyOutput}");

        return sb.ToString().TrimEnd();
    }
}