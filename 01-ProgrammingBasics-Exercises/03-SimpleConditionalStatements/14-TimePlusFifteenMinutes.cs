using System;

namespace _14_TimePlusFifteenMinutes
{
    class Program
    {
        static void Main(string[] args)
        {
            int hours, minutes;

            do
            {
                hours = int.Parse(Console.ReadLine());
                minutes = int.Parse(Console.ReadLine());
            } while (!(hours < 24 && hours >= 0 && minutes < 60 && minutes >= 0));

            minutes += 15;

            if (minutes >= 60)
            {
                hours += 1;
                minutes -= 60;

                if (hours == 24)
                {
                    hours = 0;
                }
            }

            if (minutes < 10)
            {
                Console.WriteLine("{0}:0{1}", hours, minutes);
            }
            else
            {
                Console.WriteLine("{0}:{1}", hours, minutes);
            }
        }
    }
}