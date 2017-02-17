using System;
using System.Globalization;

namespace _13.__OneThousandDaysAfterBirth
{
    class Program
    {
        static void Main(string[] args)
        {
            string currentDate = Console.ReadLine();
            string format = "dd-MM-yyyy";
            CultureInfo provider = CultureInfo.InvariantCulture;
            DateTime date = new DateTime();

            date = DateTime.ParseExact(currentDate, format, provider).AddDays(999);

            Console.WriteLine(date.ToString(format));
        }
    }
}
