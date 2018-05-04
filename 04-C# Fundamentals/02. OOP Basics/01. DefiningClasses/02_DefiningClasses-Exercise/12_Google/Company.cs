public class Company
{
    private string name;
    private string department;
    private decimal salary;
    
    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    public string Department
    {
        get { return department; }
        set { department = value; }
    }

    public decimal Salary
    {
        get { return salary; }
        set { salary = value; }
    }

    public Company(string name, string department, decimal salary)
    {
        this.Name = name;
        this.Department = department;
        this.Salary = salary;
    }
}
