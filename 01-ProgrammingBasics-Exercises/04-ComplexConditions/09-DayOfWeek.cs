using System;

namespace _09_DayOfWeek
{
    class Program
    {
        static void Main(string[] args)
        {
            string day = Console.ReadLine();
            string output = "";

            switch (day)
            {
                case "1": output = "Monday"; break;
                case "2": output = "Tuesday"; break;
                case "3": output = "Wednesday"; break;
                case "4": output = "Thursday"; break;
                case "5": output = "Friday"; break;
                case "6": output = "Saturday"; break;
                case "7": output = "Sunday"; break;
                default:
                    output = "error";
                    break;
            }

            Console.WriteLine(output);
        }
    }
}
