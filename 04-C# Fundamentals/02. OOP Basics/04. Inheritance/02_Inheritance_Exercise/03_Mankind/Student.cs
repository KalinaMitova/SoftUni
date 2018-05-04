using System;
using System.Collections.Generic;
using System.Text;

public class Student : Human
{
    private string facultyNumber;

    public string FacultyNumber
    {
        get { return facultyNumber; }
        set
        {
            foreach (var character in value)
            {
                if(!char.IsDigit(character) && !char.IsLetter(character))
                {
                    throw new ArgumentException("Invalid faculty number!");
                }
            }

            if(value.Length < 5 || value.Length > 10)
            {
                throw new ArgumentException("Invalid faculty number!");
            }

            facultyNumber = value;
        }
    }

    public Student(string firstName, string lastName, string facultyNumber)
        : base(firstName, lastName)
    {
        this.FacultyNumber = facultyNumber;
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();

        sb.AppendLine($"First Name: {this.FirstName}");
        sb.AppendLine($"Last Name: {this.LastName}");
        sb.AppendLine($"Faculty number: {this.FacultyNumber}");

        return sb.ToString();
    }
}