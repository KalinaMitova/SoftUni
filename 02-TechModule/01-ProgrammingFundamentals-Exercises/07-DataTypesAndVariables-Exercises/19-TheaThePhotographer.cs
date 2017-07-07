namespace _19_TheaThePhotographer
{
    using System;

    static class TheaThePhotographer
    {
        static void Main()
        {
            int numberOfPhotos = int.Parse(Console.ReadLine());
            int filterTime = int.Parse(Console.ReadLine());
            int filterFactor = int.Parse(Console.ReadLine());
            int uploadTime = int.Parse(Console.ReadLine());

            long filteringTime = (long)numberOfPhotos * filterTime;
            long usefulPhotos = (long)Math.Ceiling(numberOfPhotos * (filterFactor / 100d));
            long totalUploadTime = usefulPhotos * uploadTime;
            long totalTimeInSeconds = filteringTime + totalUploadTime;

            TimeSpan totalTime = TimeSpan.FromSeconds(totalTimeInSeconds);

            Console.WriteLine(totalTime.ToString(@"d\:hh\:mm\:ss"));
        }
    }
}
