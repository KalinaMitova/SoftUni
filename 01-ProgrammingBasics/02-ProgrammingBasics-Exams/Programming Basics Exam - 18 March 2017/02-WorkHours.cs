using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_WorkHours
{
    class Program
    {
        static void Main(string[] args)
        {
            int neededHours = int.Parse(Console.ReadLine());
            int workers = int.Parse(Console.ReadLine());
            int workingDays = int.Parse(Console.ReadLine());

            int totalHours = workers * workingDays * 8;

            if(neededHours <= totalHours)
            {
                Console.WriteLine("{0} hours left", totalHours - neededHours);
            }
            else
            {
                Console.WriteLine("{0} overtime", neededHours - totalHours);
                Console.WriteLine("Penalties: {0}", (neededHours - totalHours) * workingDays);
            }

        }
    }
}
