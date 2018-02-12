namespace _09_ListOfPredicates
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class ListOfPredicates
    {
        public static void Main()
        {
            int rangeNumber = int.Parse(Console.ReadLine());

            int[] dividers = Console.ReadLine()
                .Split(new char[] { }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            
            var numbers = new List<int>();

            for (int i = 1; i <= rangeNumber; i++)
            {
                bool isAllDivisible = true;

                for (int j = 0; j < dividers.Length; j++)
                {
                    if(IsValid(dividers[j], n => i % n != 0))
                    {
                        isAllDivisible = false;
                        break;
                    }
                }

                if (isAllDivisible)
                {
                    numbers.Add(i);
                }
            }

            Console.WriteLine(string.Join(" ", numbers));
        }

        private static bool IsValid(int number, Func<int, bool> condition)
        {
            return condition(number);
        }
    }
}
