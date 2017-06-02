namespace _02_CircleArea_PrecisionTwenty
{
    using System;

    static class CircleArea
    {
        static void Main()
        {
            double r = double.Parse(Console.ReadLine());
            double area = Math.PI * r * r;
            Console.WriteLine("{0:F12}", area);
        }
    }
}
