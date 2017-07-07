using System;

namespace _02_Cups
{
    class Program
    {
        static void Main(string[] args)
        {
            int cups = int.Parse(Console.ReadLine());
            int workers = int.Parse(Console.ReadLine());
            int workerDays = int.Parse(Console.ReadLine());

            int totalHours = workers * workerDays * 8;
            int totalCups = (int)Math.Floor(totalHours / 5d);

            if (totalCups < cups)
            {
                Console.WriteLine("Losses: {0:F2}", (cups - totalCups) * 4.2);
            }
            else if (totalCups >= cups)
            {
                Console.WriteLine("{0:F2} extra money", (totalCups - cups) * 4.2);
            }
        }
    }
}
