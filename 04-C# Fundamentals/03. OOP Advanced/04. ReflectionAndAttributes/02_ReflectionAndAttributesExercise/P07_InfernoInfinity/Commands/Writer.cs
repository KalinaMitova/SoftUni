using System;

public class Writer : IWriter
{
    public void WriteLine(object text)
    {
        Console.WriteLine(text);
    }
}