namespace _05_FilterByAge
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class FilterByAge
    {
        public static void Main()
        {
            Dictionary<string, int> people = new Dictionary<string, int>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                var person = Console.ReadLine()
                    .Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries);

                people.Add(person[0], int.Parse(person[1]));
            }

            string condition = Console.ReadLine();
            int age = int.Parse(Console.ReadLine());
            string format = Console.ReadLine();

            var filter = CreateFilter(condition, age);
            var printer = CreatePrinter(format);

            people.Where(filter).ToList().ForEach(printer);
        }

        private static Func<KeyValuePair<string, int>, bool> CreateFilter(string condition, int age)
        {
            switch (condition)
            {
                case "younger": return p => p.Value < age;
                case "older": return p => p.Value >= age;
                default: throw new InvalidOperationException();
            }
        }

        private static Action<KeyValuePair<string, int>> CreatePrinter(string format)
        {
            switch (format)
            {
                case "name":
                    return p => Console.WriteLine(p.Key);
                case "age":
                    return p => Console.WriteLine(p.Value);
                case "name age":
                    return p => Console.WriteLine($"{p.Key} - {p.Value}");
                default:
                    throw new NotImplementedException();
            }
        }
    }
}
