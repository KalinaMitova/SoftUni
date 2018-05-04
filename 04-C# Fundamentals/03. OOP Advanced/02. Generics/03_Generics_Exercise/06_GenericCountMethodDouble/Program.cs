using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    public static void Main(string[] args)
    {
        IList<Box<double>> boxes = new List<Box<double>>();

        int n = int.Parse(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {
            double num = double.Parse(Console.ReadLine());

            Box<double> box = new Box<double>(num);

            boxes.Add(box);
        }

        double compareElement = double.Parse(Console.ReadLine());

        int greaterElementsCount = CountGreaterElements<double>(boxes, compareElement);

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