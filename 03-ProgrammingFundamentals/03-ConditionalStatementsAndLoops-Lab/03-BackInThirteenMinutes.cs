using System;

namespace _03_BackInThirteenMinutes
{
    class Program
    {
        static void Main(string[] args)
        {
            int hours = int.Parse(Console.ReadLine());
            int minutes = int.Parse(Console.ReadLine());

            minutes += 30;
            hours += minutes / 60;
            hours %= 24;
            minutes %= 60;

            Console.WriteLine("{0}:{1:D2}", hours, minutes);
        }
    }
}
