namespace _12_RectangleProperties
{
    using System;

    static class RectangleProperties
    {
        static void Main()
        {
            double sideA = double.Parse(Console.ReadLine());
            double sideB = double.Parse(Console.ReadLine());

            double perimeter = (sideA * 2) + (sideB * 2);
            double area = sideA * sideB;
            double diagonal = Math.Sqrt(Math.Pow(sideA, 2) + Math.Pow(sideB, 2));

            Console.WriteLine(perimeter);
            Console.WriteLine(area);
            Console.WriteLine(diagonal);
        }
    }
}
