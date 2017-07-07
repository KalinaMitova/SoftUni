using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05_ClosestTwoPoints
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
            var points = ReadPoints();

            var closestTwoPoints = FindClosestTwoPoints(points);

            PrintResult(closestTwoPoints);
        }

        private static void PrintResult(Point[] closestTwoPoints)
        {
            var p1 = closestTwoPoints[0];
            var p2 = closestTwoPoints[1];

            var distance = FindDistance(p1, p2);
            Console.WriteLine("{0:F3}", distance);
            Console.WriteLine($"({p1.X}, {p1.Y})");
            Console.WriteLine($"({p2.X}, {p2.Y})");
        }

        private static Point[] FindClosestTwoPoints(Point[] points)
        {
            var closestDistance = double.MaxValue;
            Point[] closestTwoPoints = null;

            for (int p1 = 0; p1 < points.Length - 1; p1++)
            {
                for (int p2 = p1 + 1; p2 < points.Length; p2++)
                {
                    var currentDistance = FindDistance(points[p1], points[p2]);

                    if (currentDistance < closestDistance)
                    {
                        closestDistance = currentDistance;
                        closestTwoPoints = new Point[] 
                        {
                            points[p1], 
                            points[p2]
                        };
                    }
                }
            }

            return closestTwoPoints;
        }

        private static double FindDistance(Point point1, Point point2)
        {
            var sideA = Math.Abs(point1.X - point2.X);
            var sideB = Math.Abs(point1.Y - point2.Y);

            return Math.Sqrt(sideA * sideA + sideB * sideB);
        }

        private static Point[] ReadPoints()
        {
            int length = int.Parse(Console.ReadLine());
            var points = new Point[length];

            for (int i = 0; i < length; i++)
            {
                var point = Console.ReadLine().Split().Select(int.Parse).ToArray();
                points[i] = new Point()
                {
                    X = point[0],
                    Y = point[1]                
                };                
            }

            return points;
        }
    }
}
