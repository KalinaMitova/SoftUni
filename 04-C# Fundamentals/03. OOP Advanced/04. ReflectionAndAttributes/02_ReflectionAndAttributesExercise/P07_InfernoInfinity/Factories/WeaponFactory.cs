using System;
using System.Linq;
using System.Reflection;

public class WeaponFactory : IWeaponFactory
{
    public IWeapon CreateWeapon(string[] args)
    {
        string[] tokens = args[0].Split(" ");

        string weaponRarityLevel = tokens[0];
        string weaponType = tokens[1];
        string weaponName = args[1];

        RarityLevelEnum rarityLevel = Enum.Parse< RarityLevelEnum>(weaponRarityLevel);
        
        var type = Assembly.GetExecutingAssembly()
            .GetTypes()
            .Where(t => t.GetInterfaces().Contains(typeof(IWeapon)))
            .FirstOrDefault(t => t.Name == weaponType);

        IWeapon weapon = (IWeapon)Activator.CreateInstance(type, new object[] { weaponName, rarityLevel });

        return weapon;        
    }
}