namespace Forum.App.Factories
{
    using System;
    using System.Linq;
    using System.Reflection;

    using Forum.App.Contracts;

    public class MenuFactory : IMenuFactory
    {
        private IServiceProvider serviceProvider;

        public MenuFactory(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        public IMenu CreateMenu(string menuName)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            Type menuType = assembly.GetTypes()
                .FirstOrDefault(t => t.Name == menuName);

            if (menuType == null)
            {
                throw new InvalidOperationException("Menu not found!");
            }

            if (!typeof(IMenu).IsAssignableFrom(menuType))
            {
                throw new InvalidOperationException($"{menuType.Name} is not a menu!");
            }

            ParameterInfo[] ctorParameters = menuType
                .GetConstructors()
                .First()
                .GetParameters();

            object[] arguments = new object[ctorParameters.Length];

            for (int i = 0; i < arguments.Length; i++)
            {
                arguments[i] = this.serviceProvider.GetService(ctorParameters[i].ParameterType);
            }

            IMenu menu = (IMenu)Activator.CreateInstance(menuType, arguments);

            return menu;
        }
    }
}
