using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11_GeometryCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            string figure = Console.ReadLine();
            
            double area = CalcFigureArea(figure);

            Console.WriteLine($"{area:F2}");
        }

        static double CalcFigureArea(string figure)
        {
            double area = 0;
            figure = figure.ToLower();

            if (figure == "triangle")
            {
                double side = double.Parse(Console.ReadLine());
                double height = double.Parse(Console.ReadLine());
                area = side * height / 2;
            }
            else if (figure == "square")
            {
                double side = double.Parse(Console.ReadLine());
                area = side * side;
            }
            else if (figure == "rectangle")
            {
                double width = double.Parse(Console.ReadLine());
                double height = double.Parse(Console.ReadLine());
                area = width * height;
            }
            else if (figure == "circle")
            {
                double radius = double.Parse(Console.ReadLine());
                area = Math.PI * Math.Pow(radius, 2);
            }

            return Math.Round(area, 2);
        }
    }
}
