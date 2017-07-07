using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_DistanceBetweenPoints
{
    class Program
    {
        class Point
        {
            public int X { get; set; }
            public int Y { get; set; }
        }

        static void Main(string[] args)
        {
            var p1 = ReadPoint();
            var p2 = ReadPoint();

            var distance = CalcDictanceBetweenTwoPoints(p1, p2);

            Console.WriteLine("{0:F3}", distance);
        }

        private static double CalcDictanceBetweenTwoPoints(Point p1, Point p2)
        {
            var sideA = Math.Abs(p1.X - p2.X);
            var sideB = Math.Abs(p1.Y - p2.Y);

            return Math.Sqrt(sideA * sideA + sideB * sideB);
        }
        
        private static Point ReadPoint()
        {
            var points = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var point = new Point();
            point.X = points[0];
            point.Y = points[1];
            return point;
        }
    }
}
