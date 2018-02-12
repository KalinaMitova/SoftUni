namespace _13_TriFunction
{
    using System;
    using System.Linq;

    public class TriFunction
    {
        public static void Main()
        {
            int length = int.Parse(Console.ReadLine());
            string[] people = Console.ReadLine()
                .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);

            foreach (var name in people)
            {
                if(IsValid(name, length, (x, y) => x(name) >= length))
                {
                    Console.WriteLine(name);
                    break;
                }
            }
        }

        private static Func<string, int> GetSum(string name)
        {
             return x => x.Select(y => (int)y).Sum();
        }

        private static bool IsValid(string name, int length, Func<Func<string, int>, int, bool> condition)
        {
            return condition(GetSum(name), length);
        }
    }
}
