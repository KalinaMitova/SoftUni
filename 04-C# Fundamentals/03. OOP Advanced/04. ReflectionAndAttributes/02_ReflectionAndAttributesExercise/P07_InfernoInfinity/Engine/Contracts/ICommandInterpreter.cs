﻿public interface ICommandInterpreter
{
    ICommand InterpretCommand(string commandName, string[] data);
}