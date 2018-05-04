using System;
using System.Collections.Generic;

public class Person
{
    private string firstName;
    private string lastName;
    private string birthday;

    public string FirstName
    {
        get { return firstName; }
        set { firstName = value; }
    }

    public string LastName
    {
        get { return lastName; }
        set { lastName = value; }
    }


    public string Birthday
    {
        get { return birthday; }
        set { birthday = value; }
    }

    public Person()
    {

    }

    public Person(string birthday)
    {
        this.Birthday = birthday;
    }

    public Person(string firstName, string lastName)
    {
        this.FirstName = firstName;
        this.LastName = lastName;
    }

    public Person(string firstName, string lastName, string birthday)
    {
        this.FirstName = firstName;
        this.LastName = lastName;
        this.Birthday = birthday;
    }
}