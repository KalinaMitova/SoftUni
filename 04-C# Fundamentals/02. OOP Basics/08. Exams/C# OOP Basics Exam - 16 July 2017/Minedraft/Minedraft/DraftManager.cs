using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class DraftManager
{
    private double totalStoredEnergy;
    private double totalMinedOre;
    private string mode;
    private List<Harvester> harvesters;
    private List<Provider> providers;

    public DraftManager()
    {
        this.totalStoredEnergy = 0;
        this.totalMinedOre = 0;
        this.mode = "Full";
        this.harvesters = new List<Harvester>();
        this.providers = new List<Provider>();        
    }

    public string RegisterHarvester(List<string> arguments)
    {
        try
        {
            string type = arguments[0];

            Harvester harvester = HarvesterFactory.GetType(arguments);

            harvesters.Add(harvester);

            return $"Successfully registered {type} Harvester - {harvester.Id}";
        }
        catch (ArgumentException ex)
        {
            return $"Harvester is not registered, because of it's {ex.Message}";
        }        
    }

    public string RegisterProvider(List<string> arguments)
    {
        try
        {
            string type = arguments[0];

            Provider provider = ProviderFactory.GetType(arguments);

            providers.Add(provider);

            return $"Successfully registered {type} Provider - {provider.Id}";
        }
        catch (ArgumentException ex)
        {
            return $"Provider is not registered, because of it's {ex.Message}";
        }        
    }

    public string Day()
    {
        var energyProvided = providers.Sum(p => p.EnergyOutput);
        this.totalStoredEnergy += energyProvided;

        var totalHarvestersEnergy = harvesters.Sum(h => h.EnergyRequirement);

        var totalHarvestersOreOutput = harvesters.Sum(h => h.OreOutput);
        
        var plumbusOreMinded = 0d;

        if (this.totalStoredEnergy >= totalHarvestersEnergy)
        {
            if (this.mode == "Full")
            {            
                this.totalStoredEnergy -= totalHarvestersEnergy;
                this.totalMinedOre += totalHarvestersOreOutput;
                
                plumbusOreMinded += totalHarvestersOreOutput;           
            }
            else if(this.mode == "Half")
            {
                this.totalStoredEnergy -= (totalHarvestersEnergy * 0.6);
                this.totalMinedOre += (totalHarvestersOreOutput * 0.5);
                
                plumbusOreMinded += totalHarvestersOreOutput * 0.5;            
            }
        }

        StringBuilder sb = new StringBuilder();

        sb.AppendLine("A day has passed.");
        sb.AppendLine($"Energy Provided: {energyProvided}");
        sb.AppendLine($"Plumbus Ore Mined: {plumbusOreMinded}");

        return sb.ToString().TrimEnd();
    }

    public string Mode(List<string> arguments)
    {
        string mode = arguments[0];

        switch (mode)
        {
            case "Full":
            case "Half":
            case "Energy":
                this.mode = mode;
                return $"Successfully changed working mode to {this.mode} Mode";
            default:
                throw new ArgumentException();
        }        
    }

    public string Check(List<string> arguments)
    {
        string id = arguments[0];

        Harvester harvester = harvesters.SingleOrDefault(h => h.Id == id);

        StringBuilder sb = new StringBuilder();

        if(harvester != null)
        {
            return harvester.ToString();
        }

        Provider provider = providers.SingleOrDefault(p => p.Id == id);
        
        if(provider != null)
        {
            return provider.ToString();
        }

        return $"No element found with id - {id}";
    }

    public string ShutDown()
    {
        StringBuilder sb = new StringBuilder();

        sb.AppendLine($"System Shutdown");
        sb.AppendLine($"Total Energy Stored: {this.totalStoredEnergy}");
        sb.AppendLine($"Total Mined Plumbus Ore: {this.totalMinedOre}");

        return sb.ToString().TrimEnd(); 
    }
}