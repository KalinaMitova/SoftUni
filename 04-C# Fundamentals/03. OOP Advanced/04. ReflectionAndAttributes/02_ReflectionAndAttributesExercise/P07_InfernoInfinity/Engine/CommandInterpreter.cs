using System;
using System.Linq;
using System.Reflection;

public class CommandInterpreter : ICommandInterpreter
{
    IServiceProvider serviceProvider;

    public CommandInterpreter(IServiceProvider serviceProvider)
    {
        this.serviceProvider = serviceProvider;
    }

    public ICommand InterpretCommand(string commandName, string[] data)
    {
        Type commandType = Assembly.GetExecutingAssembly()
            .GetTypes()
            .Where(t => t.GetInterfaces().Contains(typeof(IExecutable)))
            .FirstOrDefault(t => t.Name.ToLower() == commandName.ToLower() + "command");

        if (commandType == null)
        {
            throw new InvalidOperationException("Invalid command!");
        }

        var services = commandType
            .GetFields(BindingFlags.NonPublic | BindingFlags.Instance)
            .Where(f => f.CustomAttributes.Any(ca => ca.AttributeType == typeof(InjectAttribute)))
            .Select(f => this.serviceProvider.GetService(f.FieldType))
            .ToArray();

        object[] args = new object[services.Length + 1];
        args[0] = data;

        for (int i = 1; i <= services.Length; i++)
        {
            args[i] = services[i - 1];
        }

        ICommand command = (ICommand)Activator.CreateInstance(commandType, args);
        
        return command;
    }
}