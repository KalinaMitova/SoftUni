using System;
using System.Reflection;

public class DescriptionCommand : ICommand
{
    [Inject]
    private IWriter writer;

    public DescriptionCommand(string[] data, IWriter writer)
    {
        this.Data = data;
        this.writer = writer;
    }

    public string[] Data { get; private set; }

    public void Execute()
    {
        Type type = typeof(Weapon);

        var attribute = (CustomAttribute)type.GetCustomAttribute(typeof(CustomAttribute));

        string description = attribute.Description;

        writer.WriteLine("Class description: " + description);
    }
}
