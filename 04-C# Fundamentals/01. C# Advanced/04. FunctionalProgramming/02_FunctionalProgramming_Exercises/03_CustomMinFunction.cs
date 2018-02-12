namespace _03_CustomMinFunction
{
    using System;
    using System.Linq;

    public class CustomMiniFunction
    {
        public static void Main()
        {
            Func<int[], int> findMinNumber = n => n.Min();

            int[] numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            Console.WriteLine(findMinNumber(numbers));
        }
    }
}
