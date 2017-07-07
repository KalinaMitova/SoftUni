using System;

namespace _12_Volleyball
{
    class Program
    {
        public static void Main()
        {
            int weekends = 48;

            string yearType = Console.ReadLine().ToLower();
            int holidays = Convert.ToInt32(Console.ReadLine());
            int sundayPlay = Convert.ToInt32(Console.ReadLine());

            double saturdayPlay = (weekends - sundayPlay) * (3.0 / 4);
            double holidayPlay = holidays * (2.0 / 3);


            double totalPlayDays = sundayPlay + saturdayPlay + holidayPlay;

            if (yearType == "leap")
            {
                totalPlayDays += totalPlayDays * 0.15;
                Console.WriteLine(Math.Truncate(totalPlayDays));
            }
            else if (yearType == "normal")
            {
                Console.WriteLine(Math.Truncate(totalPlayDays));
            }
        }
    }
}