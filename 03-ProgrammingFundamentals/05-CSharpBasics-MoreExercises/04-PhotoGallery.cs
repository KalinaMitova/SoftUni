using System;

namespace _04_PhotoGallery
{
    class Program
    {
        static void Main(string[] args)
        {
            int photoNumber = int.Parse(Console.ReadLine());
            int day = int.Parse(Console.ReadLine());
            int month = int.Parse(Console.ReadLine());
            int year = int.Parse(Console.ReadLine());
            int hours = int.Parse(Console.ReadLine());
            int minutes = int.Parse(Console.ReadLine());
            int photoSizeInBytes = int.Parse(Console.ReadLine());
            int width = int.Parse(Console.ReadLine());
            int height = int.Parse(Console.ReadLine());

            string photoSize = "";
            if (photoSizeInBytes < 1000 && photoSizeInBytes >= 0)
            {
                photoSize = photoSizeInBytes + "B";
            }
            else if (photoSizeInBytes > 999 && photoSizeInBytes < 1000000)
            {
                photoSize = (photoSizeInBytes / 1000) + "KB";
            }
            else if (photoSizeInBytes > 999999)
            {
                photoSize = Math.Round(photoSizeInBytes / 1000000d, 1) + "MB";
            }

            string photoType = "";
            if (width > height)
            {
                photoType = "landscape";
            }
            else if (width < height)
            {
                photoType = "portrait";
            }
            else
            {
                photoType = "square";
            }

            Console.WriteLine($"Name: DSC_{photoNumber:D4}.jpg");
            Console.WriteLine($"Date Taken: {day:D2}/{month:D2}/{year} {hours:D2}:{minutes:D2}");
            Console.WriteLine($"Size: {photoSize}");
            Console.WriteLine($"Resolution: {width}x{height} ({photoType})");
        }
    }
}
