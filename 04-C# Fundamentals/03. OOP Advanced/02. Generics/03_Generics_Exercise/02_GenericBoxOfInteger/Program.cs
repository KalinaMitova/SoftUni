using System;

public class Program
{
    public static void Main()
    {
        IReader reader = new ConsoleReader();

        int n = int.Parse(reader.ReadLine());

        for (int i = 0; i < n; i++)
        {
            int number = int.Parse(reader.ReadLine());

            Box<int> box = new Box<int>(number);

            Console.WriteLine(box);
        }
    }
}