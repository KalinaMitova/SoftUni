using System;
using System.Linq;

public class SequenceOfCommands_broken
{
    public static void Main()
    {
        int sizeOfArray = int.Parse(Console.ReadLine());

        long[] array = Console.ReadLine()
            .Split(' ')
            .Select(long.Parse)
            .ToArray();

        if (array.Length > sizeOfArray)
        {
            Console.WriteLine("Too meny numbers");
            return;
        }

        string[] command = Console.ReadLine().Split(' ');

        while (!command[0].Equals("stop"))
        {
            int[] args = new int[2];

            if (command[0] == "add" ||
                command[0] == "subtract" ||
                command[0] == "multiply")
            {
                args[0] = int.Parse(command[1]) - 1;
                args[1] = int.Parse(command[2]);
            }

            array = PerformAction(array, command[0], args);

            PrintArray(array);

            Console.WriteLine();

            command = Console.ReadLine().Split(' ');
        }
    }

    static long[] PerformAction(long[] arr, string action, int[] args)
    {
        long[] array = arr.Clone() as long[];
        int pos = args[0];
        int value = args[1];

        switch (action)
        {
            case "multiply":
                array[pos] *= value;
                break;
            case "add":
                array[pos] += value;
                break;
            case "subtract":
                array[pos] -= value;
                break;
            case "lshift":
                ArrayShiftLeft(array);
                break;
            case "rshift":
                ArrayShiftRight(array);
                break;
        }

        return array;
    }

    private static void ArrayShiftRight(long[] array)
    {
        long lastElement = array[array.Length - 1];
        for (int i = array.Length - 1; i >= 1; i--)
        {
            array[i] = array[i - 1];
        }
        array[0] = lastElement;
    }

    private static void ArrayShiftLeft(long[] array)
    {
        long firstElement = array[0];
        for (int i = 0; i < array.Length - 1; i++)
        {
            array[i] = array[i + 1];
        }
        array[array.Length - 1] = firstElement;
    }

    private static void PrintArray(long[] array)
    {
        for (int i = 0; i < array.Length; i++)
        {
            Console.Write(array[i] + " ");
        }
    }
}
