namespace _04_FindEvensOrOdds
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class FindEvensOrOdds
    {
        public static void Main()
        {
            int[] range = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            string oddOrEven = Console.ReadLine();

            var filter = CreateFilter(oddOrEven);

            List<int> numbers = new List<int>();
            for (int i = range[0]; i <= range[1]; i++)
            {
                if (filter(i))
                {
                    numbers.Add(i);
                }
            }

            Console.WriteLine(string.Join(" ", numbers));
        }

        private static Predicate<int> CreateFilter(string oddOrEven)
        {
            if(oddOrEven == "odd")
            {
                return n => n % 2 != 0;
            }
            else if(oddOrEven == "even")
            {
                return n => n % 2 == 0;
            }
            throw new NotImplementedException();
        }
    }
}
