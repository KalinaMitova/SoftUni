using System;


namespace _04_PointInFigure
{
    class Program
    {
        static void Main(string[] args)
        {
            int x = int.Parse(Console.ReadLine());
            int y = int.Parse(Console.ReadLine());

            int firstFigureWidth = 10;
            int firstFigureHeight = 4;
            int secondFigureWidth = 6;
            int secondFigureHeight = 8;

            if (x >= 2 && x <= 2 + firstFigureWidth && y >= -3 && y <= -3 + firstFigureHeight ||
                x >= 4 && x <= 4 + secondFigureWidth && y >= -5 && y <= -5 + secondFigureHeight)
            {
                Console.WriteLine("in");
            }
            else
            {
                Console.WriteLine("out");
            }
        }
    }
}
