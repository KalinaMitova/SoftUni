using System;

namespace _07___SumSeconds
{
    class Program
    {
        static void Main(string[] args)
        {
            string hours = Console.ReadLine();
            string minutes = Console.ReadLine();
            DateTime initialTime = DateTime.Parse(hours + ":" + minutes);
            Console.WriteLine(initialTime.AddMinutes(15).ToString("H:mm"));
        }
    }
}