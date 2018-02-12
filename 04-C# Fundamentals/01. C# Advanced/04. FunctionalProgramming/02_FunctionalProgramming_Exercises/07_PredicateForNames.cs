namespace _07_PredicateForNames
{
    using System;
    using System.Linq;

    public class PredicateForNames
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            string[] people = Console.ReadLine()
                .Split();

            Predicate<string> condition = name => name.Length <= n;

            foreach (var name in people)
            {
                if (condition(name))
                {
                    Console.WriteLine(name);
                }
            }
        }
    }
}
