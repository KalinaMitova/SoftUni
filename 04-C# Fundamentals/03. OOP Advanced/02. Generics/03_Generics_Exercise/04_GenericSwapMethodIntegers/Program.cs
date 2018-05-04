using System;
using System.Collections;
using System.Collections.Generic;

public class Program
{
    public static void Main()
    {
        IList<Box<int>> boxes = new List<Box<int>>();

        IReader reader = new ConsoleReader();

        int n = int.Parse(reader.ReadLine());

        for (int i = 0; i < n; i++)
        {
            int number = int.Parse(reader.ReadLine());

            Box<int> box = new Box<int>(number);

            boxes.Add(box);
        }

        string[] indexes = reader.ReadLine().Split();

        int baseIndex = int.Parse(indexes[0]);
        int swapIndex = int.Parse(indexes[1]);

        Swap(boxes, baseIndex, swapIndex);

        foreach (var box in boxes)
        {
            Console.WriteLine(box);
        }
    }

    public static void Swap<T>(IList<Box<T>> boxes, int baseIndex, int swapIndex)
    {
        var swaper = boxes[baseIndex];
        boxes[baseIndex] = boxes[swapIndex];
        boxes[swapIndex] = swaper;
    }
}