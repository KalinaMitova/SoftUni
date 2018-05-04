using System;
using System.Linq;

public class Engine : IEngine
{
    ICommandInterpreter commandInterpreter;

    public Engine(ICommandInterpreter commandInterpreter)
    {
        this.commandInterpreter = commandInterpreter;
    }

    public void Run()
    {
        string input;
        while ((input = Console.ReadLine()) != "END")
        {
            string[] tokens = input.Split(";");

            string commandName = tokens[0];
            string[] data = tokens.Skip(1).ToArray();

            ICommand command = this.commandInterpreter.InterpretCommand(commandName, data);
            command.Execute();
        }
    }
}