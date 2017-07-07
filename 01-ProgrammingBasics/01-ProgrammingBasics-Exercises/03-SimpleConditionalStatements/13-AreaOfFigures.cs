using System;

namespace _13_AreaOfFigures
{
    class Program
    {
        static void Main(string[] args)
        {
            string figure;
            double result;

            do
            {
                figure = Console.ReadLine();
            } while (figure != "square" && figure != "rectangle" && figure != "circle" && figure != "triangle");

            if (figure == "square")
            {
                double side = double.Parse(Console.ReadLine());
                result = Math.Pow(side, 2);
            }
            else if (figure == "rectangle")
            {
                double sideA = double.Parse(Console.ReadLine());
                double sideB = double.Parse(Console.ReadLine());
                result = sideA * sideB;
            }
            else if (figure == "circle")
            {
                double radius = double.Parse(Console.ReadLine());
                result = Math.PI * Math.Pow(radius, 2);
            }
            else
            {
                double side = double.Parse(Console.ReadLine());
                double height = double.Parse(Console.ReadLine());
                result = (side * height) / 2;
            }

            Console.WriteLine(result);
        }
    }
}