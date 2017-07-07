using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05_CalculateTriangleArea
{
    class Program
    {
        static void Main(string[] args)
        {
            double width = double.Parse(Console.ReadLine());
            double height = double.Parse(Console.ReadLine());

            double triangleArea = CalcTriangleArea(width, height);
            Console.WriteLine(triangleArea);
        }

        static double CalcTriangleArea(double width, double height)
        {
            return (width * height) / 2;
        }
    }
}
