using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

public class Program
{
    public static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        List<Employee> employees = new List<Employee>(n);

        for (int i = 0; i < n; i++)
        {
            string[] tokens = Console.ReadLine().Split();

            string name = tokens[0];
            decimal salary = decimal.Parse(tokens[1], CultureInfo.InvariantCulture);
            string position = tokens[2];
            string department = tokens[3];

            if(tokens.Length == 4)
            {
                Employee employee = new Employee(name, salary, position, department);
                employees.Add(employee);
            }
            else if(tokens.Length == 5)
            {
                int age;
                bool isNumber = int.TryParse(tokens[4], out age);
                Employee employee;

                if (isNumber)
                {
                    employee = new Employee(name, salary, position, department, age);
                }
                else
                {
                    string email = tokens[4];
                    employee = new Employee(name, salary, position, department, email);
                }

                employees.Add(employee);
            }
            else if(tokens.Length == 6)
            {
                string email = tokens[4];
                int age = int.Parse(tokens[5]);

                Employee employee = new Employee(name, salary, position, department, email, age);
                employees.Add(employee);
            }
        }

        var averageDepartment = employees
            .GroupBy(e => e.Department)
            .OrderByDescending(e => e.Average(g => g.Salary))
            .First();

        Console.WriteLine($"Highest Average Salary: {averageDepartment.Key}");
        foreach (var employee in averageDepartment.OrderByDescending(e => e.Salary))
        {
            Console.WriteLine($"{employee.Name} {employee.Salary:F2} {employee.Email} {employee.Age}");
        }
    }
}