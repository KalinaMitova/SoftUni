using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace _01_CountWorkingDays
{
    class Program
    {
        static void Main(string[] args)
        {
            var startDate = DateTime.ParseExact(
                Console.ReadLine(),
                "dd-MM-yyyy",
                CultureInfo.InvariantCulture);

            var endDate = DateTime.ParseExact(
                Console.ReadLine(),
                "dd-MM-yyyy",
                CultureInfo.InvariantCulture);

            var holidays = new DateTime[]
            {
                new DateTime(1, 1, 1),
                new DateTime(1, 3, 3),
                new DateTime(1, 5, 1),
                new DateTime(1, 5, 6),
                new DateTime(1, 5, 24),
                new DateTime(1, 9, 6),
                new DateTime(1, 9, 22),
                new DateTime(1, 11, 1),
                new DateTime(1, 12, 24),
                new DateTime(1, 12, 25),
                new DateTime(1, 12, 26),
            };

            int workDays = 0;

            for (DateTime currentDate = startDate; currentDate <= endDate; currentDate = currentDate.AddDays(1))
            {
                if (currentDate.DayOfWeek != DayOfWeek.Saturday &&
                    currentDate.DayOfWeek != DayOfWeek.Sunday)
                {
                    var isHoliday = false;
                    for (int i = 0; i < holidays.Length; i++)
                    {
                        if (holidays[i].Day == currentDate.Day &&
                           holidays[i].Month == currentDate.Month)
                        {
                            isHoliday = true;
                        }
                    }

                    if (!isHoliday)
                    {
                        workDays++;
                    }
                }
            }

            Console.WriteLine(workDays);
        }
    }
}
