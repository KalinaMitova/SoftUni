namespace _08_EmployeeData
{
    using System;

    static class EmployeeData
    {
        static void Main()
        {
            string firstName = "Amanda";
            string lastName = "Jonson";
            int age = 27;
            char gender = 'f';
            long personalId = 8306112507;
            int uniqNumber = 27563571;

            Console.WriteLine("First name: {0}", firstName);
            Console.WriteLine("Last name: {0}", lastName);
            Console.WriteLine("Age: {0}", age);
            Console.WriteLine("Gender: {0}", gender);
            Console.WriteLine("Personal ID: {0}", personalId);
            Console.WriteLine("Unique Employee number: {0}", uniqNumber);
        }
    }
}
