using System;

class Worker : Human
{
    private decimal weekSalary;
    private double workHoursPerDay;

    public Worker(string firstName, string lastName, decimal weekSalary, double workHoursPerDay)
        : base(firstName, lastName)
    {
        this.WeekSalary = weekSalary;
        this.WorkHoursPerDay = workHoursPerDay;
    }

    public decimal WeekSalary
    {
        get
        {
            return this.weekSalary;
        }
        set
        {
            if (value <= 10)
            {
                throw new ArgumentException("Expected value mismatch! Argument: weekSalary");
            }
            this.weekSalary = value;
        }
    }

    public double WorkHoursPerDay
    {
        get
        {
            return this.workHoursPerDay;
        }
        set
        {
            if (value < 1 || value > 12)
            {
                throw new ArgumentException("Expected value mismatch! Argument: workHoursPerDay");
            }
            this.workHoursPerDay = value;
        }
    }

    public decimal SalaryPerHour => (this.weekSalary / 5) / (decimal)this.WorkHoursPerDay;

    public override string ToString()
    {
        return $@"First Name: {this.FirstName}
Last Name: {this.LastName}
Week Salary: {this.weekSalary:F2}
Hours per day: {this.workHoursPerDay:F2}
Salary per hour: {this.SalaryPerHour:F2}";
    }
}