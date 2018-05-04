namespace _03BarracksFactory.Core.Commands
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    using _03BarracksFactory.Contracts;
    using _03BarracksFactory.Core.Attributes;
    using Microsoft.Extensions.DependencyInjection;

    public class CommandInterpreter : ICommandInterpreter
    {
        IServiceProvider serviceProvider;

        public CommandInterpreter(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        public IExecutable InterpretCommand(string[] data, string commandName)
        {
            Assembly assembly = Assembly.GetCallingAssembly();

            Type[] commandTypes = assembly
                .GetTypes()
                .Where(t => t.GetInterfaces()
                    .Contains(typeof(IExecutable))
                )
                .ToArray();

            string fullCommandName = commandName.ToLower() + "command";

            Type commandType = commandTypes.FirstOrDefault(m => m.Name.ToLower() == fullCommandName);

            if(commandType == null)
            {
                throw new InvalidOperationException("Invalid command!");
            }

            object[] arguments = new object[] { data };
            
            var services = commandType
                .GetFields(BindingFlags.NonPublic | BindingFlags.Instance)
                .Where(f => f.CustomAttributes.Any(a => a.AttributeType == typeof(InjectAttribute)))
                .Select(f => this.serviceProvider.GetService(f.FieldType))
                .ToArray();
            
            if(services != null)
            {
                arguments = arguments.Concat(services).ToArray();
            }

            IExecutable command = (IExecutable)Activator.CreateInstance(commandType, arguments);

            return command;
        }
    }
}
