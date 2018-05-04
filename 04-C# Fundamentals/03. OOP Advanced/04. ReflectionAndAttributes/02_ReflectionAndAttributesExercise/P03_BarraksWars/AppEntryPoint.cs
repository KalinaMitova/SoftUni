namespace _03BarracksFactory
{
    using Data;
    using Contracts;
    using Core;
    using Core.Commands;
    using Core.Factories;
    using Microsoft.Extensions.DependencyInjection;
    using System;

    class AppEntryPoint
    {
        static void Main(string[] args)
        {
            IServiceProvider serviceProvider = InitializeServices();            
            ICommandInterpreter commandInterpreter = new CommandInterpreter(serviceProvider);
            IRunnable engine = new Engine(commandInterpreter);
            engine.Run();
        }

        private static IServiceProvider InitializeServices()
        {
            IServiceCollection services = new ServiceCollection();

            services.AddTransient<IUnitFactory, UnitFactory>();
            services.AddSingleton<IRepository, UnitRepository>();

            return services.BuildServiceProvider();
        }
    }
}
