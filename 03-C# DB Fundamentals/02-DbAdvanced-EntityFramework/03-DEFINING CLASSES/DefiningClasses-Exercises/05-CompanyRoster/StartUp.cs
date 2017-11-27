using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05_CompanyRoster
{
    class StartUp
    {
        static void Main()
        {
            List<Employee> employees = new List<Employee>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] args = Console.ReadLine().Split();

                string[] mandatory = args.Take(4).ToArray();
                string[] optional = args.Skip(4).Take(2).ToArray();

                string name = mandatory[0];
                decimal salary = decimal.Parse(mandatory[1]);
                string position = mandatory[2];
                string department = mandatory[3];
                
                if (optional.Length == 0)
                {
                    employees.Add(new Employee(name, salary, position, department));
                }
                else if (optional.Length == 2)
                {
                    string email = optional[0];
                    int age = int.Parse(optional[1]);
                    employees.Add(new Employee(name, salary, position, department, email, age));
                }
                else
                {
                    int age;
                    bool isAge = int.TryParse(optional[0], out age);

                    if (isAge)
                    {
                        employees.Add(new Employee(name, salary, position, department, age));
                    }
                    else
                    {
                        string email = optional[0];
                        employees.Add(new Employee(name, salary, position, department, email));
                    }
                }
            }

            string highestSalaryDepartment = employees.GroupBy(e => e.Department)
                  .Select(g => new {
                      department = g.Key,
                      avrg = g.Average(e => e.Salary)
                  }).OrderByDescending(e => e.avrg).First().department;

            List<Employee> employeesByDepartment = employees.Where(e => e.Department == highestSalaryDepartment).ToList();

            Console.WriteLine($"Highest Average Salary: {highestSalaryDepartment}");
            foreach (var employee in employeesByDepartment
                .OrderByDescending(e => e.Salary))
            {
                Console.WriteLine(employee);
            }
        }
    }
}
