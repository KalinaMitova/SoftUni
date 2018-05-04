using System;
using System.Text;

public class Spy : Soldier, ISoldier, ISpy
{
    private int codeNumber;

    public int CodeNumber
    {
        get
        {
            return this.codeNumber;
        }
        set
        {
            if (value < 0)
            {
                throw new ArgumentException("Invalid");
            }
            this.codeNumber = value;
        }
    }

    public Spy(string id, string firstName, string lastName, int codeNumber)
        :base(id, firstName, lastName)
    {
        this.CodeNumber = codeNumber;
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();

        sb.AppendLine(base.ToString());
        sb.AppendLine($"Code Number: {this.CodeNumber}");

        return sb.ToString().TrimEnd();
    }
}