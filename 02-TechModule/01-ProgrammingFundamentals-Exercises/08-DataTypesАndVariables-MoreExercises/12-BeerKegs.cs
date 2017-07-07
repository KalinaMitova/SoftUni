namespace _12_BeerKegs
{
    using System;

    static class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            double biggestVolume = 0;
            string biggestModel = string.Empty;
            for (int i = 0; i < n; i++)
            {
                string model = Console.ReadLine();
                double radius = double.Parse(Console.ReadLine());
                int height = int.Parse(Console.ReadLine());

                double volume = Math.PI * Math.Pow(radius, 2) * height;
                
                if (biggestVolume < volume)
                {
                    biggestVolume = volume;
                    biggestModel = model;
                }               
            }

            Console.WriteLine(biggestModel);
        }
    }
}
