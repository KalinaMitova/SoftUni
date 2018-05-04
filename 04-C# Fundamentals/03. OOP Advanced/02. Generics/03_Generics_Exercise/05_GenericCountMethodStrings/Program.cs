using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    public static void Main(string[] args)
    {
        IList<Box<string>> boxes = new List<Box<string>>();

        int n = int.Parse(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {
            string text = Console.ReadLine();

            Box<string> box = new Box<string>(text);

            boxes.Add(box);
        }

        string compareElement = Console.ReadLine();

        int greaterElementsCount = CountGreaterElements<string>(boxes, compareElement);

        Console.WriteLine(greaterElementsCount);
    }

    private static int CountGreaterElements<T>(IList<Box<T>> boxes, T compareElement) 
        where T : IComparable<T>
    {
        int counter = 0;

        foreach (var box in boxes)
        {
            if (box.Value.CompareTo(compareElement) > 0)
            {
                counter++;
            }
        }

        return counter;
    }
}