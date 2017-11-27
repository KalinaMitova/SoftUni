using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_DateModifier
{
    class StartUp
    {
        static void Main(string[] args)
        {
            string firstDate = Console.ReadLine();
            string secondDate = Console.ReadLine();

            DateModifier date = new DateModifier(firstDate, secondDate);

            Console.WriteLine(date.GetDaysDifference());
        }
    }
}
