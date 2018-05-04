public class Person
{
    private string firstName;
    private string lastName;
    private int age;
    private decimal salary;

    public string FirstName
    {
        get { return firstName; }
    }
    
    public string LastName
    {
        get { return lastName; }
    }
    
    public int Age
    {
        get { return age; }
    }

    public decimal Salary
    {
        get { return salary; }
        set { salary = value; }
    }
    
    public Person(string firstName, string lastName, int age, decimal salary)
    {
        this.firstName = firstName;
        this.lastName = lastName;
        this.age = age;
        this.salary = salary;
    }

    public void IncreaseSalary(decimal bonus)
    {
        if (this.Age > 30)
        {
            this.Salary += this.Salary * bonus / 100;
        }
        else
        {
            this.Salary += this.Salary * bonus / 200;
        }
    }

    public override string ToString()
    {
        return $"{this.FirstName} {this.LastName} receives {this.Salary:F2} leva."; 
    }
}