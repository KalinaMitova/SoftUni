namespace _08_CustomComparator
{
    using System;
    using System.Linq;

    public class CustomComparator
    {
        public static void Main()
        {
            Comparison<int> comparison = (x, y) => 
                x % 2 == 0 && y % 2 == 0 ? x - y : x % 2 == 0 ? -1 : y % 2 == 0 ? 1 : x - y;

            int[] numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            Array.Sort(numbers, comparison);

            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
