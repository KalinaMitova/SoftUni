namespace _06_ReverseAndExclude
{
    using System;
    using System.Linq;

    public class ReverseAndExclude
    {
        public static void Main()
        {
            int[] numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int n = int.Parse(Console.ReadLine());

            Func<int, bool> condition = x => x % n != 0;

            numbers = numbers.Where(condition).Reverse().ToArray();

            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
