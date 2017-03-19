using System;

namespace _03_Vacation
{
    class Program
    {
        static void Main(string[] args)
        {
            double budged = double.Parse(Console.ReadLine());
            string season = Console.ReadLine().ToLower();

            string accommodation = "";
            string location = "";
            double price = 0.0;

            if (budged <= 1000)
            {
                accommodation = "Camp";
                switch (season)
                {
                    case "summer":
                        location = "Alaska";
                        price = 0.65;
                        break;
                    case "winter":
                        location = "Morocco";
                        price = 0.45;
                        break;
                }
            }
            else if (budged > 1000 && budged <= 3000)
            {
                accommodation = "Hut";
                switch (season)
                {
                    case "summer":
                        location = "Alaska";
                        price = 0.8;
                        break;
                    case "winter":
                        location = "Morocco";
                        price = 0.6;
                        break;
                }
            }
            else
            {
                accommodation = "Hotel";
                price = 0.9;
                switch (season)
                {
                    case "summer":
                        location = "Alaska";
                        break;
                    case "winter":
                        location = "Morocco";
                        break;
                }
            }

            Console.WriteLine("{0} - {1} - {2:F2}", location, accommodation, budged * price);
        }
    }
}
