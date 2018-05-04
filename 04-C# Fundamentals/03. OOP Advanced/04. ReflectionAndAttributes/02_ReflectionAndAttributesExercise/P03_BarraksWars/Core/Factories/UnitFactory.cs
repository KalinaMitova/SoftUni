namespace _03BarracksFactory.Core.Factories
{
    using System;
    using System.Linq;
    using System.Reflection;
    using _03BarracksFactory.Contracts;

    public class UnitFactory : IUnitFactory
    {
        public IUnit CreateUnit(string unitType)
        {
            Assembly assembly = Assembly.GetCallingAssembly();
            Type[] unitTypes = assembly.GetTypes().Where(t => t.GetInterfaces().Contains(typeof(IUnit))).ToArray();
            Type unit = unitTypes.FirstOrDefault(t => t.Name == unitType);
            IUnit instance = (IUnit)Activator.CreateInstance(unit);
            return instance;
        }
    }
}
