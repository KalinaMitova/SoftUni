using System;

namespace _03_Megapixels
{
    class Program
    {
        static void Main(string[] args)
        {
            int width = int.Parse(Console.ReadLine());
            int height = int.Parse(Console.ReadLine());
            double megapixels = Math.Round((width * height) / 1000000d, 1);

            Console.WriteLine($"{width}x{height} => {megapixels}MP");
        }
    }
}
