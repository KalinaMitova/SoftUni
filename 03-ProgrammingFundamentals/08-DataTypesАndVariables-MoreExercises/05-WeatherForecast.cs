namespace _05_WeatherForecast
{
    using System;

    static class WeatherForecast
    {
        static void Main()
        {
            decimal number = decimal.Parse(Console.ReadLine());

            if (number % 1 != 0)
            {
                Console.WriteLine("Rainy");
            }
            else
            {
                if (number >= sbyte.MinValue && number <= sbyte.MaxValue)
                {
                    Console.WriteLine("Sunny");
                }
                else if (number >= int.MinValue && number <= int.MaxValue)
                {
                    Console.WriteLine("Cloudy");
                }
                else if(number >= long.MinValue && number <= long.MaxValue)
                {
                    Console.WriteLine("Windy");
                }
                else
                {
                    Console.WriteLine("incorrect number");
                }
            }
            
        }
    }
}
