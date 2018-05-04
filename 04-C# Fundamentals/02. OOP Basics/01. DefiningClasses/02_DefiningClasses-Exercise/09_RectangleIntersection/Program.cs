using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    public static void Main()
    {
        List<Rectangle> rectangles = new List<Rectangle>();

        string[] nm = Console.ReadLine().Split();

        int n = int.Parse(nm[0]);
        int m = int.Parse(nm[1]);

        for (int i = 0; i < n; i++)
        {
            string[] tokens = Console.ReadLine().Split();

            string id = tokens[0];
            double width = double.Parse(tokens[1]);
            double height = double.Parse(tokens[2]);

            double x = double.Parse(tokens[3]);
            double y = double.Parse(tokens[4]);

            Rectangle rect = new Rectangle(id, width, height, x, y);

            rectangles.Add(rect);
        }

        for (int i = 0; i < m; i++)
        {
            string[] rects = Console.ReadLine().Split();

            Rectangle firstRect = rectangles.First(r => r.Id == rects[0]);
            Rectangle secondRect = rectangles.First(r => r.Id == rects[1]);

            Console.WriteLine(firstRect.isIntersect(secondRect) ? "true" : "false");
        }
    }
}