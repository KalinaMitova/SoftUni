using System;
using System.Linq;
using System.Reflection;

public class Tracker
{
    public static void PrintMethodsByAuthor()
    {
        MethodInfo[] methods = typeof(StartUp)
            .GetMethods(BindingFlags.Static | BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)
            .Where(m => m.CustomAttributes.Any(a => a.AttributeType == typeof(SoftUniAttribute)))
            .ToArray();
        
        foreach (MethodInfo method in methods)
        {
            var attrs = method.GetCustomAttributes(false);
            foreach (SoftUniAttribute attr in attrs)
            {
                Console.WriteLine($"{method.Name} is written by {attr.Name}");
            }
        }
    }
}
