namespace _01_ReverseStrings
{
    using System;
    using System.Collections.Generic;

    public class ReverseStrings
    {
        public static void Main()
        {
            string input = Console.ReadLine();
            Stack<char> characters = new Stack<char>();

            foreach (var ch in input)
            {
                characters.Push(ch);
            }

            foreach (var ch in characters)
            {
                Console.Write(ch);
            }
            Console.WriteLine();
        }
    }
}
