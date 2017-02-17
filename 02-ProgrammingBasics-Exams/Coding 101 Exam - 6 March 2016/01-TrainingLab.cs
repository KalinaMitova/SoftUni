using System;

namespace _01.Training_Lab
{
    class Program
    {
        static void Main(string[] args)
        {
            double h = double.Parse(Console.ReadLine()) * 100;
            double w = double.Parse(Console.ReadLine()) * 100;

            double a = Math.Floor((w - 100) / 70);
            double b = Math.Floor(h / 120);

            Console.WriteLine(a * b - 3);
        }
    }
}
