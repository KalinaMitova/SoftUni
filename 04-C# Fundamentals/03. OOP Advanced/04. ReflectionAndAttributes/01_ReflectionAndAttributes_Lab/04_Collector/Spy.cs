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

    public string RevealPrivateMethods(string className)
    {
        Type classType = Type.GetType(className);

        StringBuilder sb = new StringBuilder();

        sb.AppendLine($"All Private Methods of Class: {className}");
        sb.AppendLine($"Base Class: {classType.BaseType.Name}");

        MethodInfo[] methods = classType.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic);

        foreach (MethodInfo method in methods)
        {
            sb.AppendLine(method.Name);
        }

        return sb.ToString().Trim();
    }

    public string CollectGettersAndSetters(string className)
    {
        Type classType = Type.GetType(className);

        PropertyInfo[] properties = classType.GetProperties(BindingFlags.Public | BindingFlags.NonPublic |
            BindingFlags.Instance | BindingFlags.Static);

        MethodInfo[] getMethods = properties.Select(p => p.GetMethod).ToArray();
        MethodInfo[] setMethods = properties.Select(p => p.SetMethod).ToArray();

        StringBuilder sb = new StringBuilder();

        foreach (MethodInfo getMethod in getMethods)
        {
            string methodName = getMethod.Name;
            string methodReturnType = getMethod.ReturnType.FullName;

            sb.AppendLine($"{methodName} will return {methodReturnType}");
        }

        foreach (MethodInfo setMethod in setMethods)
        {
            if(setMethod != null)
            {
                string methodName = setMethod.Name;
                string methodReturnType = setMethod.GetParameters().First().ParameterType.FullName;

                sb.AppendLine($"{methodName} will set field of {methodReturnType}");
            }
        }

        return sb.ToString().Trim();
    }
}