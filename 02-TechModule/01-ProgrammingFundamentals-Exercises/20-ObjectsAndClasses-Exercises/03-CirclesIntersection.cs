using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_CirclesIntersection
{
    class Program
    {
        class Circle
        {
            public Point Center { get; set; }
            public double Radius { get; set; }
        }

        class Point
        {
            public int X { get; set; }
            public int Y { get; set; }
        }

        static void Main(string[] args)
        {
            var circle1 = ReadInput();
            var circle2 = ReadInput();

            bool isIntersect = Intersect(circle1, circle2);

            Console.WriteLine(isIntersect ? "Yes" : "No");
        }

        private static bool Intersect(Circle circle1, Circle circle2)
        {
            var sideA = Math.Abs(circle1.Center.X - circle2.Center.X);
            var sideB = Math.Abs(circle1.Center.Y - circle2.Center.Y);
            var distanceBetweenCenters = Math.Sqrt(sideA * sideA + sideB * sideB);

            var intersect = false;

            if (distanceBetweenCenters <= circle1.Radius + circle2.Radius)
            {
                intersect = true;
            }

            return intersect;
        }

        private static Circle ReadInput()
        {
            var line =
                Console.ReadLine()
                .Split();

            var circlePoint = new Point();
            circlePoint.X = int.Parse(line[0]);
            circlePoint.Y = int.Parse(line[1]);

            var circle = new Circle();
            circle.Center = circlePoint;
            circle.Radius = double.Parse(line[2]);

            return circle;
        }
    }
}
