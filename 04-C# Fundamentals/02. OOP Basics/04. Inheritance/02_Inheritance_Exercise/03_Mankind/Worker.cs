using System;
using System.Collections.Generic;
using System.Text;

public class Worker : Human
{
    private double weekSalary;
    private double workHoursPerDay;

    public double WeekSalary
    {
        get { return weekSalary; }
        set
        {
            if(value <= 10)
            {
                throw new ArgumentException("Expected value mismatch! Argument: weekSalary");
            }
            weekSalary = value;
        }
    }
    
    public double WorkHoursPerDay
    {
        get { return workHoursPerDay; }
        set
        {
            if(value < 1 || value > 12)
            {
                throw new ArgumentException("Expected value mismatch! Argument: workHoursPerDay");
            }

            workHoursPerDay = value;
        }
    }

    public double SalaryPerHour
    {
        get => (this.WeekSalary / 5) / this.WorkHoursPerDay;
    }

    public Worker(string firstName, string lastName, double weekSalary, double workHoursPerDay)
        : base(firstName, lastName)
    {
        this.WeekSalary = weekSalary;
        this.WorkHoursPerDay = workHoursPerDay;
    }
    
    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();

        sb.AppendLine($"First Name: {this.FirstName}");
        sb.AppendLine($"Last Name: {this.LastName}");
        sb.AppendLine($"Week Salary: {this.WeekSalary:F2}");
        sb.AppendLine($"Hours per day: {this.WorkHoursPerDay:F2}");
        sb.AppendLine($"Salary per hour: {this.SalaryPerHour:F2}");
        
        return sb.ToString();
    }
}