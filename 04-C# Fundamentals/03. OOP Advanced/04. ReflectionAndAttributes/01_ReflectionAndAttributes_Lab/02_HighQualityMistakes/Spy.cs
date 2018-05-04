using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

public class Spy
{
    public string StealFieldInfo(string classToInvestigate, params string[] fieldsToInvestigate)
    {
        Type classType = Type.GetType(classToInvestigate);

        FieldInfo[] fields = classType.GetFields(
            BindingFlags.NonPublic | BindingFlags.Public |
            BindingFlags.Static | BindingFlags.Instance);

        StringBuilder sb = new StringBuilder();

        object classInstance = Activator.CreateInstance(classType, new object[] { });

        sb.AppendLine($"Class under investigation: {classType.FullName}");

        foreach (FieldInfo field in fields.Where(f => fieldsToInvestigate.Contains(f.Name)))
        {
            sb.AppendLine($"{field.Name} = {field.GetValue(classInstance)}");
        }

        return sb.ToString().Trim();
    }

    public string AnalyzeAcessModifiers(string className)
    {
        Type classType = Type.GetType(className);

        FieldInfo[] fields = classType.GetFields(BindingFlags.Instance | 
            BindingFlags.Static | BindingFlags.Public);

        StringBuilder sb = new StringBuilder();

        foreach (FieldInfo field in fields)
        {
            sb.AppendLine($"{field.Name} must be private!");
        }

        PropertyInfo[] properties = classType.GetProperties(BindingFlags.Instance |
            BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);

        MethodInfo[] getMethods = properties.Select(p => p.GetMethod).ToArray();
        MethodInfo[] setMethods = properties.Select(p => p.SetMethod).ToArray();

        foreach (MethodInfo getMethod in getMethods)
        {
            if (getMethod.IsPrivate)
            {
                sb.AppendLine($"{getMethod.Name} have to be public!");
            }
        }

        foreach (MethodInfo setMethod in setMethods)
        {
            if (setMethod?.IsPublic ?? false)
            {
                sb.AppendLine($"{setMethod.Name} have to be private!");
            }
        }

        return sb.ToString().Trim();
    }
}