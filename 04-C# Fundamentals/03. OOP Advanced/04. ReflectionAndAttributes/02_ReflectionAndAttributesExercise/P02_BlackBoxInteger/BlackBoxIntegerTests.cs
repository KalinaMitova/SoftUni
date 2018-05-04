namespace P02_BlackBoxInteger
{
    using System;
    using System.Reflection;

    public class BlackBoxIntegerTests
    {
        public static void Main()
        {
            Type classType = typeof(BlackBoxInteger);
            ConstructorInfo constructor = classType.GetConstructor(BindingFlags.NonPublic | BindingFlags.Instance, null,
                new Type[] { typeof(int) }, new ParameterModifier[] { });
            BlackBoxInteger box = (BlackBoxInteger)constructor.Invoke(new object[] { 0 });

            string input;
            while ((input = Console.ReadLine()) != "END")
            {
                string[] args = input.Split("_".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                string methodName = args[0];
                int value = int.Parse(args[1]);

                MethodInfo method = classType.GetMethod(methodName, BindingFlags.Instance | BindingFlags.NonPublic);
                
                method.Invoke(box, new object[] { value });

                int result = (int)classType
                    .GetField("innerValue", BindingFlags.Instance | BindingFlags.NonPublic)
                    .GetValue(box);

                Console.WriteLine(result);
            }
        }
    }
}
