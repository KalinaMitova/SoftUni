namespace _04_TouristInformation
{
    using System;

    static class TouristInformation
    {
        static void Main()
        {
            string initialImperialUnit = Console.ReadLine().ToLower();
            double initialValue = double.Parse(Console.ReadLine());

            double convertedValue = 0.0;
            string metricUnit = "";

            switch (initialImperialUnit)
            {
                case "miles":
                    convertedValue = initialValue * 1.6;
                    metricUnit = "kilometers";
                    break;
                case "inches":
                    convertedValue = initialValue * 2.54;
                    metricUnit = "centimeters";
                    break;
                case "feet":
                    convertedValue = initialValue * 30;
                    metricUnit = "centimeters";
                    break;
                case "yards":
                    convertedValue = initialValue * 0.91;
                    metricUnit = "meters";
                    break;
                case "gallons":
                    convertedValue = initialValue * 3.8;
                    metricUnit = "liters";
                    break;
                default:
                    Console.WriteLine("incorrect imperial unit");
                    break;
            }

            Console.WriteLine($"{initialValue} {initialImperialUnit} = {convertedValue:F2} {metricUnit}");
        }
    }
}
