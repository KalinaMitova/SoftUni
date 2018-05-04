using System;
using System.Reflection;

public class ReviewersCommand : ICommand
{
    [Inject]
    private IWriter writer;

    public ReviewersCommand(string[] data, IWriter writer)
    {
        this.Data = data;
        this.writer = writer;
    }

    public string[] Data { get; private set; }

    public void Execute()
    {
        Type type = typeof(Weapon);

        var attribute = (CustomAttribute)type.GetCustomAttribute(typeof(CustomAttribute));

        string[] reviewers = attribute.Reviewers;

        writer.WriteLine("Reviewers: " + string.Join(", ", reviewers));
    }
}

