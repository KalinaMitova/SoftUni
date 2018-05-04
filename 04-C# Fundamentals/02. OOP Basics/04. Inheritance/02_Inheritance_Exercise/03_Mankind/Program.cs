using System;

public class Program
{
    public static void Main()
    {
        try
        {
            string[] studentInput = Console.ReadLine()
                .Split(" ".ToCharArray(), StringSplitOptions.None);

            string studentFirstName = studentInput[0];
            string studentLastName = studentInput[1];
            string studentFacultyNumber = studentInput[2];

            Student student = new Student(studentFirstName, studentLastName, studentFacultyNumber);

            string[] workerInput = Console.ReadLine()
                .Split(" ".ToCharArray(), StringSplitOptions.None);

            string workerFirstName = workerInput[0];
            string workerLastName = workerInput[1];
            double workerWeekSalary = double.Parse(workerInput[2]);
            double workerWorkHoursPerDay = double.Parse(workerInput[3]);

            Worker worker = new Worker(workerFirstName, workerLastName, workerWeekSalary, workerWorkHoursPerDay);

            Console.WriteLine(student);
            Console.WriteLine(worker);
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}