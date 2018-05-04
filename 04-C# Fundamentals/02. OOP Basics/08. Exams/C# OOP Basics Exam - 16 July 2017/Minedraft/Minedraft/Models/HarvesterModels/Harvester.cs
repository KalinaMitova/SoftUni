using System;
using System.Text;

public abstract class Harvester : MainId
{
    private double oreOutput;
    private double energyRequirement;

    protected Harvester(string id, double oreOutput, double energyRequirement)
        :base(id)
    {
        this.OreOutput = oreOutput;
        this.EnergyRequirement = energyRequirement;
    }
    
    public double OreOutput
    {
        get
        {
            return this.oreOutput;
        }
        protected set
        {
            if (value < 0)
            {
                throw new ArgumentException(nameof(OreOutput));
            }
            this.oreOutput = value;
        }
    }

    public double EnergyRequirement
    {
        get
        {
            return this.energyRequirement;
        }
        protected set
        {
            if (value < 0 || value > 20000)
            {
                throw new ArgumentException(nameof(EnergyRequirement));
            }
            this.energyRequirement = value;
        }
    }


    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();

        sb.AppendLine($"Harvester - {this.Id}");
        sb.AppendLine($"Ore Output: {this.OreOutput}");
        sb.AppendLine($"Energy Requirement: {this.EnergyRequirement}");

        return sb.ToString().TrimEnd();
    }
}