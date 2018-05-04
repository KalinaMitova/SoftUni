using System;

public class Person
{
    private const int MIN_NAME_LENGTH = 3;
    private const int MIN_AGE = 0;
    private const decimal MIN_SALARY = 460m;

    private string firstName;
    private string lastName;
    private int age;
    private decimal salary;

    public string FirstName
    {
        get { return firstName; }
        set
        {
            if (value?.Length < MIN_NAME_LENGTH)
            {
                throw new ArgumentException($"First name cannot contain fewer than {MIN_NAME_LENGTH} symbols!");
            }
            firstName = value;
        }
    }
    
    public string LastName
    {
        get { return lastName; }
        set
        {
            if(value?.Length < MIN_NAME_LENGTH)
            {
                throw new ArgumentException($"Last name cannot contain fewer than {MIN_NAME_LENGTH} symbols!");
            }
            lastName = value;
        }
    }
    
    public int Age
    {
        get { return age; }
        set
        {
            if(value <= MIN_AGE)
            {
                throw new ArgumentException("Age cannot be zero or a negative integer!");
            }
            age = value;
        }
    }

    public decimal Salary
    {
        get { return salary; }
        set
        {
            if(value < MIN_SALARY)
            {
                throw new ArgumentException($"Salary cannot be less than {MIN_SALARY} leva!");
            }
            salary = value;
        }
    }
    
    public Person(string firstName, string lastName, int age, decimal salary)
    {
        this.FirstName = firstName;
        this.LastName = lastName;
        this.Age = age;
        this.Salary = salary;
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