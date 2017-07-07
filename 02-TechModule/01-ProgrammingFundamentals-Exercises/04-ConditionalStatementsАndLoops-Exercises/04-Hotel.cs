using System;

namespace _04_Hotel
{
    class Program
    {
        static void Main(string[] args)
        {
            string month = Console.ReadLine();
            int nightsCount = int.Parse(Console.ReadLine());

            double studioPrice = 0d;
            double doublePrice = 0d;
            double suitePrice = 0d;

            switch (month.ToLower())
            {
                case "may":
                case "october":
                    studioPrice = 50;
                    doublePrice = 65;
                    suitePrice = 75;
                    if (nightsCount > 7)
                    {
                        studioPrice *= 0.95;
                    }
                    break;
                case "june":
                case "september":
                    studioPrice = 60;
                    doublePrice = 72;
                    suitePrice = 82;
                    if (nightsCount > 14)
                    {
                        doublePrice *= 0.9;
                    }
                    break;
                case "july":
                case "august":
                case "december":
                    studioPrice = 68;
                    doublePrice = 77;
                    suitePrice = 89;
                    if (nightsCount > 14)
                    {
                        suitePrice *= 0.85;
                    }
                    break;
            }

            double studioTotalPrice = nightsCount * studioPrice;
            double doubleTotalPrice = nightsCount * doublePrice;
            double suiteTotalPrice = nightsCount * suitePrice;

            if (nightsCount > 7 && (month == "September" || month == "October"))
            {
                studioTotalPrice -= studioPrice;
            }

            Console.WriteLine($"Studio: {studioTotalPrice:F2} lv.");
            Console.WriteLine($"Double: {doubleTotalPrice:F2} lv.");
            Console.WriteLine($"Suite: {suiteTotalPrice:F2} lv.");
        }
    }
}
