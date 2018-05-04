using System;

public class Repair : IRepair
{
    private string partName;
    private int hoursWorked;

    public string PartName
    {
        get
        {
            return this.partName;
        }
        set
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentException("Invalid");
            }
            this.partName = value;
        }
    }

    public int HoursWorked
    {
        get
        {
            return this.hoursWorked;
        }
        set
        {
            if (value < 0)
            {
                throw new ArgumentException("Invalid");
            }
            this.hoursWorked = value;
        }
    }

    public Repair(string partName, int hoursWorked)
    {
        this.PartName = partName;
        this.HoursWorked = hoursWorked;
    }

    public override string ToString()
    {
        return $"Part Name: {this.PartName} Hours Worked: {this.HoursWorked}";
    }
}