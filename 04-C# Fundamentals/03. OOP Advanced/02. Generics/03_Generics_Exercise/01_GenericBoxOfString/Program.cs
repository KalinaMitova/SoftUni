using System;

public class Program
{
    public static void Main()
    {
        IReader reader = new ConsoleReader();

        int n = int.Parse(reader.ReadLine());

        for (int i = 0; i < n; i++)
        {
            string line = reader.ReadLine();

            Box<string> box = new Box<string>(line);

            Console.WriteLine(box);
        }
    }
}