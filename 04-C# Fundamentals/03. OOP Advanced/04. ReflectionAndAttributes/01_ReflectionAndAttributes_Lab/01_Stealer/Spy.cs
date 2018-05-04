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
}