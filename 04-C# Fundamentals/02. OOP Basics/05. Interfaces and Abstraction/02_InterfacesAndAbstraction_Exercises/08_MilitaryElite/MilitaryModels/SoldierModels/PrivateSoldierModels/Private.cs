using System;

public class Private : Soldier, ISoldier, IPrivate
{
    private double salary;

    public double Salary
    {
        get
        {
            return this.salary;
        }
        set
        {
            if (value < 0)
            {
                throw new ArgumentException("Invalid");
            }
            this.salary = value;
        }
    }

    public Private(string id, string firstName, string lastName, double salary)
        : base(id, firstName, lastName)
    {
        this.Salary = salary;
    }

    public override string ToString()
    {
        return base.ToString() + $" Salary: {this.Salary:F2}";
    }
}