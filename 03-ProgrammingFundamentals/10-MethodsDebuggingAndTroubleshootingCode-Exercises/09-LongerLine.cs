using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09_LongerLine
{
    class Program
    {
        static void Main(string[] args)
        {
            double firstPointX = double.Parse(Console.ReadLine());
            double firstPointY = double.Parse(Console.ReadLine());
            double secondPointX = double.Parse(Console.ReadLine());
            double secondPointY = double.Parse(Console.ReadLine());
            double thirdPointX = double.Parse(Console.ReadLine());
            double thirdPointY = double.Parse(Console.ReadLine());
            double fourthPointX = double.Parse(Console.ReadLine());
            double fourthPointY = double.Parse(Console.ReadLine());

            double firstPointDistance = FindDistance(firstPointX, firstPointY);
            double secondPointDistance = FindDistance(secondPointX, secondPointY);
            double thirdPointDistance = FindDistance(thirdPointX, thirdPointY);
            double fourthPointDistance = FindDistance(fourthPointX, fourthPointY);

            if (firstPointDistance + secondPointDistance >= thirdPointDistance + fourthPointDistance)
            {
                PrintShortestPointDistance(firstPointDistance, secondPointDistance,
                    firstPointX, firstPointY, secondPointX, secondPointY);
            }
            else
            {
                PrintShortestPointDistance(thirdPointDistance, fourthPointDistance,
                    thirdPointX, thirdPointY, fourthPointX, fourthPointY);
            }
        }

        private static void PrintShortestPointDistance(double firstPointDistance, double secondPointDistance,
            double x1, double y1, double x2, double y2)
        {
            if (firstPointDistance <= secondPointDistance)
            {
                Console.WriteLine($"({x1}, {y1})({x2}, {y2})");
            }
            else
            {
                Console.WriteLine($"({x2}, {y2})({x1}, {y1})");
            }
        }

        static double FindDistance(double x, double y)
        {
            return Math.Sqrt(Math.Pow(x, 2) + Math.Pow(y, 2));
        }
    }
}