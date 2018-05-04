using System.Collections.Generic;
using System.Text;

public class Engineer : SpecialisedSoldier, IEngineer
{
    private ICollection<IRepair> repairs;

    public Engineer(int id, string firstName, string lastName, decimal salary, string corps)
        : base(id, firstName, lastName, salary, corps)
    {
        this.repairs = new List<IRepair>();
    }

    public IReadOnlyCollection<IRepair> Repairs => (IReadOnlyCollection<IRepair>)this.repairs;

    public void AddRepair(IRepair repair)
    {
        repairs.Add(repair);
    }
    
    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();

        sb.AppendLine(base.ToString());
        sb.AppendLine($"Corps: {this.Corps.ToString()}");
        sb.AppendLine($"Repairs:");

        foreach (var r in this.Repairs)
        {
            sb.AppendLine("  " + r.ToString());
        }

        return sb.ToString().TrimEnd();
    }
}