using System;

namespace _08___MetricConverter
{
    class Program
    {
        static void Main(string[] args)
        {
            double metric = double.Parse(Console.ReadLine());
            string inMetric = Console.ReadLine();
            string outMetric = Console.ReadLine();

            double metricToMeter = 0.0;
            double result = 0.0;

            switch (inMetric)
            {
                case "m": metricToMeter = metric; break;
                case "mm": metricToMeter = metric / 1000; break;
                case "cm": metricToMeter = metric / 100; break;
                case "mi": metricToMeter = metric / 0.000621371192; break;
                case "in": metricToMeter = metric / 39.3700787; break;
                case "km": metricToMeter = metric / 0.001; break;
                case "ft": metricToMeter = metric / 3.2808399; break;
                case "yd": metricToMeter = metric / 1.0936133; break;
            }

            switch (outMetric)
            {
                case "m": result = metricToMeter; break;
                case "mm": result = metricToMeter * 1000; break;
                case "cm": result = metricToMeter * 100; break;
                case "mi": result = metricToMeter * 0.000621371192; break;
                case "in": result = metricToMeter * 39.3700787; break;
                case "km": result = metricToMeter * 0.001; break;
                case "ft": result = metricToMeter * 3.2808399; break;
                case "yd": result = metricToMeter * 1.0936133; break;
            }

            Console.WriteLine(result + " " + outMetric);
        }
    }
}