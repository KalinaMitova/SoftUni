using System;

namespace _02_SleepyTomCat
{
    class Program
    {
        static void Main(string[] args)
        {
            int holidays = int.Parse(Console.ReadLine());
            int playNorm = 30000;
            int timeForPlay = (365 - holidays) * 63 + holidays * 127;

            double lessForPlay = Math.Abs(playNorm - timeForPlay);
            int hours = (int)lessForPlay / 60;
            int minutes = (int)lessForPlay % 60;

            if (timeForPlay <= playNorm)
            {
                Console.WriteLine("Tom sleeps well");
                Console.WriteLine("{0} hours and {1} minutes less for play", hours, minutes);
            }
            else
            {
                Console.WriteLine("Tom will run away");
                Console.WriteLine("{0} hours and {1} minutes more for play", hours, minutes);
            }
        }
    }
}