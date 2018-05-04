using System.Collections.Generic;
using System.Text;

public class Engineer : SpecialisedSoldier, ISoldier, IPrivate, ISpecialisedSoldier, IEngineer
{
    public List<IRepair> Repairs { get; set; }

    public Engineer(string id, string firstName, string lastName, double salary, CorpsEnum corps, List<IRepair> repairs)
        : base(id, firstName, lastName, salary, corps)
    {
        this.Repairs = repairs;
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();

        sb.AppendLine(base.ToString());
        sb.AppendLine($"Corps: {this.Corps}");
        sb.AppendLine($"Repairs:");

        foreach (var r in Repairs)
        {
            sb.AppendLine("  " + r.ToString());
        }
        
        return sb.ToString().TrimEnd();
    }
}