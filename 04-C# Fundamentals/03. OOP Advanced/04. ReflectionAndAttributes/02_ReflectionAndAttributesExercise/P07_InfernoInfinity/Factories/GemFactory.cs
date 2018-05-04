using System;
using System.Linq;
using System.Reflection;

public class GemFactory : IGemFactory
{
    public IGem CreateGem(string[] args)
    {
        string clarityLevelInput = args[0];
        string gemType = args[1];

        ClarityLevelEnum clarityLevel = Enum.Parse<ClarityLevelEnum>(clarityLevelInput);

        var type = Assembly.GetExecutingAssembly()
            .GetTypes()
            .Where(t => t.GetInterfaces().Contains(typeof(IGem)))
            .FirstOrDefault(t => t.Name == gemType);

        IGem gem = (IGem)Activator.CreateInstance(type, new object[] { clarityLevel });

        return gem;
    }
}