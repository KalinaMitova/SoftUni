using System;
using System.Reflection;

public class RevisionCommand : ICommand
{
    [Inject]
    private IWriter writer;

    public RevisionCommand(string[] data, IWriter writer)
    {
        this.Data = data;
        this.writer = writer;
    }

    public string[] Data { get; private set; }

    public void Execute()
    {
        Type type = typeof(Weapon);

        var attribute = (CustomAttribute)type.GetCustomAttribute(typeof(CustomAttribute));

        int revision = attribute.Revision;

        writer.WriteLine("Revision: " + revision);
    }
}
