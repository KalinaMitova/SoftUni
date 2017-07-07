using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08_CenterPoint
{
    class Program
    {
        static void Main(string[] args)
        {
            double firstPointX = double.Parse(Console.ReadLine());
            double firstPointY = double.Parse(Console.ReadLine());
            double secondPointX = double.Parse(Console.ReadLine());
            double secondPointY = double.Parse(Console.ReadLine());

            double firstPointDistance = FindDistance(firstPointX, firstPointY);
            double secondPointDistance = FindDistance(secondPointX, secondPointY);

            if(firstPointDistance <= secondPointDistance)
            {
                Console.WriteLine($"({firstPointX}, {firstPointY})");
            }
            else
            {
                Console.WriteLine($"({secondPointX}, {secondPointY})");
            }
        }

        static double FindDistance(double x, double y)
        {
            return Math.Sqrt(Math.Pow(x, 2) + Math.Pow(y, 2));
        }
    }
}
