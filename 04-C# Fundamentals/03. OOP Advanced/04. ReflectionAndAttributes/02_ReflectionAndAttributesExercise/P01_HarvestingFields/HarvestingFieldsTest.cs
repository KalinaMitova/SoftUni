 namespace P01_HarvestingFields
{
    using System;
    using System.Linq;
    using System.Reflection;
    using System.Text;

    public class HarvestingFieldsTest
    {
        public static void Main()
        {
            string input;
            while((input = Console.ReadLine()) != "HARVEST")
            {
                string output = GetFieldsByType(input);

                Console.WriteLine(output);
            }
        }

        private static string GetFieldsByType(string accessModifier)
        {
            Type type = typeof(HarvestingFields);

            FieldInfo[] privateFields = type
                .GetFields(BindingFlags.Public | BindingFlags.NonPublic 
                | BindingFlags.Static | BindingFlags.Instance);

            if(accessModifier == "public")
            {
                privateFields = privateFields.Where(f => f.IsPublic).ToArray();
            }
            else if (accessModifier == "private")
            {
                privateFields = privateFields.Where(f => f.IsPrivate).ToArray();
            }
            else if (accessModifier == "protected")
            {
                privateFields = privateFields.Where(f => f.IsFamily).ToArray();
            }

            StringBuilder sb = new StringBuilder();

            foreach (FieldInfo field in privateFields.ToArray())
            {
                string fieldAccessModifier = field.IsPublic ? "public" : field.IsPrivate ? "private" : field.IsFamily ? "protected" : string.Empty;
                sb.AppendLine($"{fieldAccessModifier} {field.FieldType.Name} {field.Name}");
            }

            return sb.ToString().Trim();
        }
    }
}
