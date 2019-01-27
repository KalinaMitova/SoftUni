namespace _02_MountainRun
{
    using System;

    class Program
    {
        static void Main(string[] args)
        {
            double record = double.Parse(Console.ReadLine());
            double distance = double.Parse(Console.ReadLine());
            double timeInSeconds = double.Parse(Console.ReadLine());

            // на всеки 50м с 30 сек

            double timeForDistance = timeInSeconds * distance;
            double delayCount = Math.Floor(distance / 50.0);

            double totalTime = timeForDistance + delayCount * 30;

            if (record > totalTime)
            {
                Console.WriteLine("Yes! The new record is {0:F2} seconds.", totalTime);
            }
            else
            {
                double neededTime = totalTime - record;
                Console.WriteLine("No! He was {0:F2} seconds slower.", neededTime);
            }
        }
    }
}
