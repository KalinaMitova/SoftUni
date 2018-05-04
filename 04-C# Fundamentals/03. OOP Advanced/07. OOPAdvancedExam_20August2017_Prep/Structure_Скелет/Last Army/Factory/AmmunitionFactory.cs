using System;
using System.Linq;
using System.Reflection;

public class AmmunitionFactory : IAmmunitionFactory
{
    public IAmmunition CreateAmmunition(string name)
    {
        Type type = Assembly.GetCallingAssembly().GetTypes()
            .FirstOrDefault(t => t.Name == name);

        return (IAmmunition)Activator.CreateInstance(type);
    }
}