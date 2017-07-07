using System;

namespace _02_Farm
{
    class Program
    {
        static void Main(string[] args)
        {
            int hours = int.Parse(Console.ReadLine());
            int days = int.Parse(Console.ReadLine());
            int workers = int.Parse(Console.ReadLine());

            double workingHours = ((days * 0.9) * 8) + (workers * days * 2);

            if (hours <= workingHours)
            {
                Console.WriteLine("Yes!{0} hours left.", Math.Floor(workingHours) - hours);
            }
            else
            {
                Console.WriteLine("Not enough time!{0} hours needed.", hours - Math.Floor(workingHours));
            }
        }
    }
}
