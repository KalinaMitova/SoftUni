using System;

namespace _08.__TriangleArea
{
    class Program
    {
        static void Main(string[] args)
        {
            double a = double.Parse(Console.ReadLine());
            double h = double.Parse(Console.ReadLine());

            double area = Math.Round(a * h / 2, 2);

            Console.WriteLine("Triangle area = {0}", area);
        }
    }
}