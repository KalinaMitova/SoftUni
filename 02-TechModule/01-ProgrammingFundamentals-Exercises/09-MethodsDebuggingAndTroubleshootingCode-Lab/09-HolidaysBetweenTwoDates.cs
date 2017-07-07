using System;
using System.Globalization;

namespace _09_HolidaysBetweenTwoDates
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] formats = { "dd.MM.yyyy", "d.MM.yyyy", "dd.M.yyyy", "d.M.yyyy" };
            var startDate = DateTime.ParseExact(Console.ReadLine(),
                formats, CultureInfo.InvariantCulture, DateTimeStyles.None);
            var endDate = DateTime.ParseExact(Console.ReadLine(),
                formats, CultureInfo.InvariantCulture, DateTimeStyles.None);

            var holidaysCount = 0;
            for (var date = startDate; date <= endDate; date = date.AddDays(1))
            {
                if (date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday)
                {
                    holidaysCount++;
                }
            }
            Console.WriteLine(holidaysCount);
        }
    }
}
