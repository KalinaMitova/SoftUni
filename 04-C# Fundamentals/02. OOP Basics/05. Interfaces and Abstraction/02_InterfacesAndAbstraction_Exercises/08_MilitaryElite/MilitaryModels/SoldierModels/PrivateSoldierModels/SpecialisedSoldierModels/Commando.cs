using System.Collections.Generic;
using System.Text;

public class Commando : SpecialisedSoldier, ISoldier, IPrivate, ISpecialisedSoldier, ICommando
{
    public List<IMission> Missions { get; set; }

    public Commando(string id, string firstName, string lastName, double salary, CorpsEnum corps, List<IMission> missions)
        : base(id, firstName, lastName, salary, corps)
    {
        this.Missions = missions;
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();

        sb.AppendLine(base.ToString());
        sb.AppendLine($"Corps: {this.Corps}");
        sb.AppendLine("Missions:");

        foreach (var m in Missions)
        {
            sb.AppendLine("  " + m.ToString());
        }
        
        return sb.ToString().TrimEnd();
    }
}