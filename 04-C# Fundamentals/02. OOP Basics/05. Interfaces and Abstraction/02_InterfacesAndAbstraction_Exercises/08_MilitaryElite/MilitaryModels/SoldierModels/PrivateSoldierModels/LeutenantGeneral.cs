using System.Collections.Generic;
using System.Text;

public class LeutenantGeneral : Private, ISoldier, IPrivate, ILeutenantGeneral
{
    public List<ISoldier> Privates { get; set; }

    public LeutenantGeneral(string id, string firstName, string lastName, double salary, List<ISoldier> privates)
        : base(id, firstName, lastName, salary)
    {
        this.Privates = privates;
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();

        sb.AppendLine(base.ToString());
        sb.AppendLine("Privates:");

        foreach (var p in Privates)
        {
            sb.AppendLine("  " + p.ToString());
        }

        return sb.ToString().TrimEnd();
    }
}