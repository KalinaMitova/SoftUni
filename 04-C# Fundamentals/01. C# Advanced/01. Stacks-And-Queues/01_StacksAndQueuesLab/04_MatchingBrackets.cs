namespace _04_MatchingBrackets
{
    using System;
    using System.Collections.Generic;

    public class MatchingBrackets
    {
        public static void Main()
        {
            string input = Console.ReadLine();
            Stack<int> openBackets = new Stack<int>();

            for (int i = 0; i < input.Length; i++)
            {
                if(input[i] == '(')
                {
                    openBackets.Push(i);
                }
                else if (input[i] == ')')
                {
                    int startIndex = openBackets.Pop();
                    int length = i - startIndex + 1;
                    Console.WriteLine(input.Substring(startIndex, length));
                }
            }
        }
    }
}
