using System;
using System.Text;

public class SonicHarvester : Harvester
{
    private int sonicFactor;

    public SonicHarvester(string id, double oreOutput, double energyRequirement, int sonicFactor) 
        : base(id, oreOutput, energyRequirement)
    {
        this.SonicFactor = sonicFactor;
        this.EnergyRequirement /= this.SonicFactor;
    }

    public int SonicFactor
    {
        get { return sonicFactor; }
        set
        {
            if(value < 1 || value > 10)
            {
                throw new ArgumentException(nameof(SonicFactor));
            }
            sonicFactor = value;
        }
    }

    public override string ToString()
    {
        return "Sonic " + base.ToString();
    }
}