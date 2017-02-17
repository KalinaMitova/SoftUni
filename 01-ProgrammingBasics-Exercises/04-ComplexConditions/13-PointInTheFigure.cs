using System;

namespace _13_PointInTheFigure
{
    class Program
    {
        static void Main(string[] args)
        {
            int h = Convert.ToInt32(Console.ReadLine());
            int x = Convert.ToInt32(Console.ReadLine());
            int y = Convert.ToInt32(Console.ReadLine());

            int firstFigureWidth = h * 3;
            int firstFigureHeight = h;

            int secondFigureWidth = h;
            int secondFigureHeight = h * 3;

            if ((x > 0 && x < firstFigureWidth) && (y > 0 && y < firstFigureHeight) ||
                (x > secondFigureWidth && x < secondFigureWidth + h) && (y > 0 && y < h + secondFigureHeight))
            {
                Console.WriteLine("inside");
            }
            else if (!((x >= 0 && x <= firstFigureWidth) && (y >= 0 && y <= firstFigureHeight) ||
                (x >= secondFigureWidth && x <= secondFigureWidth + h) && (y >= 0 && y <= h + secondFigureHeight)))
            {
                Console.WriteLine("outside");
            }
            else
            {
                Console.WriteLine("border");
            }
        }
    }
}
