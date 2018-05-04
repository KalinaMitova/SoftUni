using System;
using System.Reflection;

public class AuthorCommand : ICommand
{
    [Inject]
    private IWriter writer;

    public AuthorCommand(string[] data, IWriter writer)
    {
        this.Data = data;
        this.writer = writer;
    }

    public string[] Data { get; private set; }
     
    public void Execute()
    {
        Type type = typeof(Weapon);

        var attribute = (CustomAttribute)type.GetCustomAttribute(typeof(CustomAttribute));

        string author = attribute.Author;

        writer.WriteLine("Author: " + author);
    }
}