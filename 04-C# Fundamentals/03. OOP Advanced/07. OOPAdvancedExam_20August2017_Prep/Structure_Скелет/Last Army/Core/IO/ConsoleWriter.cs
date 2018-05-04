using System;
using System.Text;

public class ConsoleWriter : IWriter
{
    private StringBuilder builder;

    public ConsoleWriter()
    {
        this.builder = new StringBuilder();
    }

    public void AppendLine(string line)
    {
        this.builder.AppendLine(line);
    }

    public void WriteAllText()
    {
        Console.WriteLine(this.builder.ToString().Trim());
    }
}