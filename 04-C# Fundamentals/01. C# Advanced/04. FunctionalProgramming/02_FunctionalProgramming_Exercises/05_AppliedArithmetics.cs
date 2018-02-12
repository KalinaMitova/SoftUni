namespace _05_AppliedArithmetics
{
    using System;
    using System.Linq;

    public class AppliedArithmetics
    {
        public static void Main()
        {
            int[] numbers = Console.ReadLine()
                .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            string input;
            while ((input = Console.ReadLine()) != "end")
            {
                if (input == "print")
                {
                    Console.WriteLine(string.Join(" ", numbers));
                    continue;
                }

                var command = CommandParser(input);

                numbers = numbers.Select(command).ToArray();
            }
        }

        private static Func<int, int> CommandParser(string command)
        {
            switch (command)
            {
                case "add":
                    return x => x += 1;
                case "multiply":
                    return x => x *= 2;
                case "subtract":
                    return x => x -= 1;
                default:
                    throw new NotImplementedException();
            }
        }
    }
}
