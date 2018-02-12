namespace _07_BalancedParentheses
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class BalancedParentheses
    {
        public static void Main()
        {
            Stack<char> stack = new Stack<char>();

            string brackets = Console.ReadLine();
            
            for (int i = 0; i < brackets.Length; i++)
            {
                var currentBracket = brackets[i];

                if (currentBracket == '(' ||
                    currentBracket == '{' ||
                    currentBracket == '[')
                {
                    stack.Push(currentBracket);
                }
                else
                {
                    if(stack.Count == 0)
                    {
                        Console.WriteLine("NO");
                        return;
                    }

                    char lastOpenBracket = stack.Pop();

                    if((currentBracket == ')' && lastOpenBracket != '(') ||
                        (currentBracket == '}' && lastOpenBracket != '{') ||
                        (currentBracket == ']' && lastOpenBracket != '['))
                    {
                        Console.WriteLine("NO");
                        return;
                    }
                }
            }
            Console.WriteLine("YES");
        }
    }
}
