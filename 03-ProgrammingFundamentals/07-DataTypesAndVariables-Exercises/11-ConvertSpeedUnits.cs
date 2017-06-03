namespace _11_ConvertSpeedUnits
{
    using System;

    static class ConvertSpeedUnits
    {
        static void Main()
        {
            int distanceInMeters = int.Parse(Console.ReadLine());
            int hours = int.Parse(Console.ReadLine());
            int minutes = int.Parse(Console.ReadLine());
            int seconds = int.Parse(Console.ReadLine());

            TimeSpan totalTime = new TimeSpan(hours, minutes, seconds);

            float metersPerSec = distanceInMeters / (float)totalTime.TotalSeconds;

            float distanceInKilometers = distanceInMeters / 1000;
            float kilometersPerHour = distanceInKilometers / (float)totalTime.TotalHours;

            float distanceInMiles = distanceInMeters / 1609f;
            float milesPerHour = distanceInMiles / (float)totalTime.TotalHours;

            Console.WriteLine(metersPerSec);
            Console.WriteLine(kilometersPerHour);
            Console.WriteLine(milesPerHour);
        }
    }
}
