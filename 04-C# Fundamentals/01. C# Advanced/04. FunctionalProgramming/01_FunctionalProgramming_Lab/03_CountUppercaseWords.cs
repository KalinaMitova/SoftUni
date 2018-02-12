namespace _03_CountUppercaseWords
{
    using System;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            Func<string, bool> checker = w => char.IsUpper(w[0]);

            string text = Console.ReadLine();

            string[] words = text
                .Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
                .Where(checker)
                .ToArray();

            foreach (var word in words)
            {
                Console.WriteLine(word);
            }
        }
    }
}
