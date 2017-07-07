using System;

namespace _06.__CircleAreaAndPerimeter
{
    class Program
    {
        static void Main(string[] args)
        {
            double r = double.Parse(Console.ReadLine());

            var area = Math.PI * Math.Pow(r, 2);
            var perimeter = 2 * Math.PI * r;

            Console.WriteLine("Area = {0}", area);
            Console.WriteLine("Perimeter = {0}", perimeter);
        }
    }
}