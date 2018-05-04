namespace P04_WorkForce
{
    using System;
    using System.Collections.Generic;

    using P04_WorkForce.Models;
    using P04_WorkForce.Contracts;

    public class Program
    {
        public static void Main()
        {
            List<IEmployee> employees = new List<IEmployee>();
            JobList jobs = new JobList();

            string input;
            while ((input = Console.ReadLine()) != "End")
            {
                string[] tokens = input.Split();

                string command = tokens[0];

                switch (command)
                {
                    case "Job":
                        {
                            string jobName = tokens[1];
                            int jobHours = int.Parse(tokens[2]);
                            string employeeName = tokens[3];

                            IEmployee employee = employees.Find(e => e.Name == employeeName);

                            IJob job = new Job(jobName, jobHours, employee);
                            jobs.Add(job);

                            job.OnJobIsDone += jobs.OnJobIsDone;
                            jobs.OnPassWeek += job.Update;
                        }
                        break;
                    case "StandardEmployee":
                        {
                            string name = tokens[1];

                            IEmployee employee = new StandardEmployee(name);

                            employees.Add(employee);
                        }
                        break;
                    case "PartTimeEmployee":
                        {
                            string name = tokens[1];

                            IEmployee employee = new PartTimeEmployee(name);

                            employees.Add(employee);
                        }
                        break;
                    case "Pass":
                        {
                            jobs.PassWeek();
                        }
                        break;
                    case "Status":
                        {
                            jobs.Status();
                        }
                        break;
                }
            }
        }
    }
}
