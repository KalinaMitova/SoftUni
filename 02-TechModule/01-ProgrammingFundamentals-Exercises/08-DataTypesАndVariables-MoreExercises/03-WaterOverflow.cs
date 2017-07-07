namespace _03_WaterOverflow
{
    using System;

    static class WaterOverflow
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            int waterTank = 0;
            for (int i = 0; i < n; i++)
            {
                int liters = int.Parse(Console.ReadLine());

                if (255 - waterTank >= liters)
                {
                    waterTank += liters;
                }
                else
                {
                    Console.WriteLine("Insufficient capacity!");
                }
            }
            Console.WriteLine(waterTank);
        }
    }
}
