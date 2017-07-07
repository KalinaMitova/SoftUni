using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace _01_DayOfWeek
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();

            DateTime date = 
                DateTime.ParseExact(input, "d-M-yyyy", CultureInfo.InvariantCulture);

            Console.WriteLine(date.DayOfWeek);
        }
    }
}
