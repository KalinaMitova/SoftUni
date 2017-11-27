using System;
using P02_DatabaseFirst.Data;
using P02_DatabaseFirst.Data.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

namespace P02_DatabaseFirst
{
    class StartUp
    {
        static void Main(string[] args)
        {
            // 15.	Remove Towns
            //var townName = Console.ReadLine();

            //using (var db = new SoftUniContext())
            //{
            //    try
            //    {
            //        var town = db.Towns.SingleOrDefault(t => t.Name == townName);

            //        var addresses = db.Addresses
            //        .Where(a => a.TownId == town.TownId).ToList();

            //        var employees = db.Employees
            //            .Where(e => addresses.Any(a => a.AddressId == e.AddressId))
            //            .ToList();

            //        foreach (var emp in employees)
            //        {
            //            emp.AddressId = null;
            //        }

            //        db.Addresses.RemoveRange(addresses);
            //        db.Towns.Remove(town);

            //        db.SaveChanges();

            //        Console.WriteLine($"{addresses.Count()} addresses in {townName} were deleted");
            //    }
            //    catch (Exception)
            //    {
            //        Console.WriteLine($"There is no town with name {townName}");
            //    }
            //}

            //14.	Delete Project by Id
            //using (var db = new SoftUniContext())
            //{
            //    var projectId = 2;

            //    var project = db.Projects.Find(projectId);

            //    var projectsToRemove = db.EmployeesProjects
            //        .Where(ep => ep.ProjectId == projectId).ToList();

            //    db.EmployeesProjects.RemoveRange(projectsToRemove);

            //    db.Projects.Remove(project);

            //    db.SaveChanges();

            //    var projects = db.Projects.Take(10);

            //    foreach (var p in projects)
            //    {
            //        Console.WriteLine(p.Name);
            //    }
            //}

            //13.	Find Employees by First Name Starting With Sa
            //using (var db = new SoftUniContext())
            //{
            //    var employees = db.Employees
            //        .Where(e => e.FirstName.StartsWith("Sa"))
            //        .Select(e => new
            //        {
            //            e.FirstName,
            //            e.LastName,
            //            e.JobTitle,
            //            e.Salary
            //        })
            //        .OrderBy(e => e.FirstName)
            //        .ThenBy(e => e.LastName)
            //        .ToList();

            //    foreach (var emp in employees)
            //    {
            //        Console.WriteLine($"{emp.FirstName} {emp.LastName} - {emp.JobTitle} - (${emp.Salary:F2})");
            //    }
            //}

            //12.	Increase Salaries
            //string[] departments = {
            //    "Engineering",
            //    "Tool Design",
            //    "Marketing",
            //    "Information Services"
            //};

            //using (var db = new SoftUniContext())
            //{
            //    var employees = db.Employees
            //        .Where(e => departments.Any(d => d == e.Department.Name))
            //        .ToList();

            //    foreach (var emp in employees)
            //    {
            //        emp.Salary *= 1.12m;
            //    }

            //    db.SaveChanges();

            //    foreach (var emp in employees
            //        .OrderBy(e => e.FirstName)
            //        .ThenBy(e => e.LastName))
            //    {
            //        Console.WriteLine($"{emp.FirstName} {emp.LastName} (${emp.Salary:F2})");
            //    }
            //}

            //11.	Find Latest 10 Projects
            //CultureInfo ci = CultureInfo.InvariantCulture;
            //using (var db = new SoftUniContext())
            //{
            //    var projects = db.Projects
            //        .OrderByDescending(p => p.StartDate)
            //        .Take(10)
            //        .ToList();

            //    foreach (var project in projects.OrderBy(p => p.Name))
            //    {
            //        Console.WriteLine(project.Name);
            //        Console.WriteLine(project.Description);
            //        Console.WriteLine(project.StartDate.ToString("M/d/yyyy h:mm:ss tt", ci));
            //    }
            //}

            //10.	Departments with More Than 5 Employees
            //using (var db = new SoftUniContext())
            //{
            //    var departmens = db.Departments
            //        .Where(d => d.Employees.Count() > 5)
            //        .Include(d => d.Manager)
            //        .Include(d => d.Employees)
            //        .OrderBy(d => d.Employees.Count())
            //        .ThenBy(d => d.Name)                    
            //        .ToList();

            //    foreach (var dep in departmens)
            //    {
            //        Console.WriteLine($"{dep.Name} - {dep.Manager.FirstName} {dep.Manager.LastName}");

            //        foreach (var emp in dep.Employees.OrderBy(e => e.FirstName).ThenBy(e => e.LastName))
            //        {
            //            Console.WriteLine($"{emp.FirstName} {emp.LastName} - {emp.JobTitle}");
            //        }

            //        Console.WriteLine("----------");
            //    }
            //}

            //9. Employee 147
            //using (var db = new SoftUniContext())
            //{
            //    var employee = db.Employees
            //        .Include(p => p.EmployeesProjects)
            //        .FirstOrDefault(e => e.EmployeeId == 147);

            //    Console.WriteLine($"{employee.FirstName} {employee.LastName} - {employee.JobTitle}");

            //    var projects = db.Projects
            //        .Where(p => employee.EmployeesProjects
            //                     .Any(ep => ep.ProjectId == p.ProjectId))
            //        .OrderBy(p => p.Name)
            //        .ToList();

            //    foreach (var p in projects)
            //    {
            //        Console.WriteLine(p.Name);
            //    }                
            //}

            //8. Addresses by Town
            //using (var db = new SoftUniContext())
            //{
            //    var addresses = db.Addresses
            //        .OrderByDescending(a => a.Employees.Count())
            //        .ThenBy(a => a.Town.Name)
            //        .ThenBy(a => a.AddressText)
            //        .Take(10)
            //        .Select(a => new {
            //            a.AddressText,
            //            TownName = a.Town.Name,
            //            EmployeeCount = a.Employees.Count()
            //        })
            //        .ToList();

            //    foreach (var address in addresses)
            //    {
            //        Console.WriteLine($"{address.AddressText}, {address.TownName} - {address.EmployeeCount} employees");
            //    }
            //}

            //7.Employees and Projects
            //CultureInfo ci = CultureInfo.InvariantCulture;
            //using (var db = new SoftUniContext())
            //{
            //    var employees = db.Employees
            //        .Where(e => e.EmployeesProjects
            //                    .Any(ep => ep.Project.StartDate.Year >= 2001 &&                                        
            //                             ep.Project.StartDate.Year <= 2003))
            //        .Select(e => new {
            //            e.FirstName,
            //            e.LastName,
            //            ManagerFirstName = e.Manager.FirstName,
            //            ManagerLastName = e.Manager.LastName,
            //            e.EmployeesProjects
            //        })
            //        .Take(30);

            //    foreach (var emp in employees)
            //    {
            //        Console.WriteLine($"{emp.FirstName} {emp.LastName} - Manager: {emp.ManagerFirstName} {emp.ManagerLastName}");                    
            //        foreach (var pr in emp.EmployeesProjects)
            //        {
            //            var project = db.Projects.Find(pr.ProjectId);

            //            Console.Write($"--{project.Name} - {project.StartDate.ToString("M/d/yyyy h:mm:ss tt", ci)} - ");

            //            if (project.EndDate != null)
            //            {
            //                Console.WriteLine($"{project.EndDate.Value.ToString("M/d/yyyy h:mm:ss tt", ci)}");
            //            }
            //            else
            //            {
            //                Console.WriteLine("not finished");
            //            }
            //        }
            //    }
            //}

            //6.	Adding a New Address and Updating Employee
            //using (var db = new SoftUniContext())
            //{
            //    var address = new Address()
            //    {
            //        AddressText = "Vitoshka 15",
            //        TownId = 4
            //    };

            //    var employee = db.Employees
            //        .FirstOrDefault(e => e.LastName == "Nakov");

            //    employee.Address = address;

            //    db.SaveChanges();

            //    var employees = db.Employees
            //        .OrderByDescending(e => e.AddressId)
            //        .Take(10)
            //        .Select(e => new
            //        {
            //            e.Address.AddressText
            //        });

            //    foreach (var emp in employees)
            //    {
            //        Console.WriteLine(emp.AddressText);
            //    }
            //}

            //5. Employees from Research and Development
            //using (var db = new SoftUniContext())
            //{
            //    var employees = db.Employees
            //        .Where(e => e.Department.Name == "Research and Development")
            //        .OrderBy(e => e.Salary)
            //        .ThenByDescending(e => e.FirstName)
            //        .Select(e => new
            //        {
            //            e.FirstName,
            //            e.LastName,
            //            DepartmentName = e.Department.Name,
            //            e.Salary
            //        });

            //    foreach (var emp in employees)
            //    {
            //        //Gigi Matthew from Research and Development - $40900.00
            //        Console.WriteLine($"{emp.FirstName} {emp.LastName} from {emp.DepartmentName} - ${emp.Salary:F2}");
            //    }
            //}

            //4.	Employees with Salary Over 50 000
            //using (var db = new SoftUniContext())
            //{
            //    var employees = db.Employees
            //        .Where(e => e.Salary > 50000)
            //        .Select(e => new { e.FirstName })
            //        .OrderBy(e => e.FirstName).ToList();

            //    foreach (var emp in employees)
            //    {
            //        Console.WriteLine(emp.FirstName);
            //    }
            //}

            // 3. Employees Full Information
            //using(var db = new SoftUniContext())
            //{
            //    var employees = db.Employees
            //        .Select(e => new
            //        {
            //            e.EmployeeId,
            //            e.FirstName,
            //            e.LastName,
            //            e.MiddleName,
            //            e.JobTitle,
            //            e.Salary
            //        })
            //        .OrderBy(e => e.EmployeeId)
            //        .ToList();

            //    foreach (var employee in employees)
            //    {
            //        Console.WriteLine($"{employee.FirstName} {employee.LastName} {employee.MiddleName} {employee.JobTitle} {employee.Salary:F2}");
            //    }                
            //}
        }
    }
}
