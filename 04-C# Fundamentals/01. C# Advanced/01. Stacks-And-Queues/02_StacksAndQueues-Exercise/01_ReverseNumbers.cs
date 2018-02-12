namespace _01_ReverseNumbers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class ReverseNumbers
    {
        public static void Main()
        {
            //1 2 3 4 5
            string[] numbers = Console.ReadLine().Split(' ');

            Stack<string> integers = new Stack<string>(numbers);

            string[] reversedNumbers = new string[numbers.Length];

            int numbersLength = integers.Count;

            for (int i = 0; i < numbersLength; i++)
            {
                reversedNumbers[i] = integers.Pop();
            }

            Console.WriteLine(string.Join(" ", reversedNumbers));
        }
    }
}
