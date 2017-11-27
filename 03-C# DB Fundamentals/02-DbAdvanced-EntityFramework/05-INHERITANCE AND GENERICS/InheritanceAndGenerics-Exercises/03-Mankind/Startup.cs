using System;

class StartUp
{
    static void Main(string[] args)
    {
        try
        {
            var studentInput = Console.ReadLine().Split();
            var studentFirstName = studentInput[0];
            var studentLastName = studentInput[1];
            var studentFacultyNumber = studentInput[2];

            var workerInput = Console.ReadLine().Split();
            var workerFirstName = workerInput[0];
            var workerLastName = workerInput[1];
            var workerWeekSalary = decimal.Parse(workerInput[2]);
            var workerWorkHoursPerDay = double.Parse(workerInput[3]);

            var student = new Student(studentFirstName, studentLastName, studentFacultyNumber);
            var worker = new Worker(workerFirstName, workerLastName, workerWeekSalary, workerWorkHoursPerDay);

            Console.WriteLine(student + Environment.NewLine);
            Console.WriteLine(worker);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }
}