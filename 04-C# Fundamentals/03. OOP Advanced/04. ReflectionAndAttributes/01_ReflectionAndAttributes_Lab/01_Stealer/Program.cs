using System;

public class Program
{
    public static void Main(string[] args)
    {
        Spy spy = new Spy();

        string info = spy.StealFieldInfo("System.Text.StringBuilder", "MaxChunkSize", "ThreadIDField");

        Console.WriteLine(info);
    }
}
