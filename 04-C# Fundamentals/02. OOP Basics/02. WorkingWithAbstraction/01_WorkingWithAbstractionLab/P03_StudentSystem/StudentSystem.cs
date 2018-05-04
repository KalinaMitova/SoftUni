using System;
using System.Collections.Generic;
using System.Globalization;

public class StudentSystem
{
    private Dictionary<string, Student> repository;

    public StudentSystem()
    {
        repository = new Dictionary<string, Student>();
    }
    
    public void ParseCommand(string command, Action<string> printFunction)
    {
        string[] args = command.Split();

        if (args[0] == "Create")
        {
            Create(args[1], args[2], args[3]);
        }
        else if (args[0] == "Show")
        {
            Show(args[1], printFunction);
        }
    }

    private void Show(string name, Action<string> printFunction)
    {
        if (repository.ContainsKey(name))
        {
            printFunction(repository[name].ToString());
        }
    }

    private void Create(string name, string ageString, string gradeString)
    {
        var age = int.Parse(ageString);
        var grade = double.Parse(gradeString, CultureInfo.InvariantCulture);
        if (!repository.ContainsKey(name))
        {
            var student = new Student(name, age, grade);
            repository[name] = student;
        }
    }
}