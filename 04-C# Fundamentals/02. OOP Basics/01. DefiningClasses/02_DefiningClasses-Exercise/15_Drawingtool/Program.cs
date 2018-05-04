using System;

public class Program
{
    public static void Main()
    {
        string input = Console.ReadLine();

        Figure figure = new Figure();
        if (input == "Square")
        {
            int side = int.Parse(Console.ReadLine());

            figure = new Figure(side, side);
        }
        else if (input == "Rectangle")
        {
            int sideA = int.Parse(Console.ReadLine());
            int sideB = int.Parse(Console.ReadLine());

            figure = new Figure(sideA, sideB);
        }

        DrawingTool drawingTool = new DrawingTool(figure);
        drawingTool.Draw();
    }
}