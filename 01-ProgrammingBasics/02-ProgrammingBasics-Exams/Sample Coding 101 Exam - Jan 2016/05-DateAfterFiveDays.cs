using System;

namespace _05_DateAfterFiveDays
{
    class Program
    {
        static void Main(string[] args)
        {
            int d = int.Parse(Console.ReadLine());
            int m = int.Parse(Console.ReadLine());
            int monthDays = 31;

            if(m == 2)
            {
                monthDays = 28;
            }
            else if(m == 4 || m == 6 || m == 9 || m == 11)
            {
                monthDays = 30;
            }

            if (d > monthDays || d < 1 || m < 1 || m > 12) return;

            int plusFiveDays = (d + 5) % monthDays == 0 ? monthDays : (d + 5) % monthDays;

            if (d > plusFiveDays) m++;
            if (m > 12) m = 1;

            string month = "0" + m;

            Console.WriteLine("{0}.{1}", plusFiveDays, month.Substring(month.Length - 2, 2));
        }
    }
}
