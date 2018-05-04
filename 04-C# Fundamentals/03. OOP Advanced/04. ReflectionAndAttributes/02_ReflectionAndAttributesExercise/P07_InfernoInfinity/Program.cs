using Microsoft.Extensions.DependencyInjection;

namespace P07_InfernoInfinity
{
    public class Program
    {
        public static void Main(string[] args)
        {
            ServiceProvider serviceProvider = InitializeServices();
            ICommandInterpreter commandInterpreter = new CommandInterpreter(serviceProvider);
            Engine engine = new Engine(commandInterpreter);
            engine.Run();
        }

        private static ServiceProvider InitializeServices()
        {
            IServiceCollection services = new ServiceCollection();

            services.AddSingleton<IRepository, WeaponRepository>();
            services.AddTransient<IWeaponFactory, WeaponFactory>();
            services.AddTransient<IGemFactory, GemFactory>();
            services.AddTransient<IWriter, Writer>();

            return services.BuildServiceProvider();
        }
    }
}
