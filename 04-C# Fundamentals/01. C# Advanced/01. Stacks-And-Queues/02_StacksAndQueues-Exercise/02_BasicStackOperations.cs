namespace _02_BasicStackOperations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class BasicStackOperations
    {
        public static void Main()
        {
            Stack<int> stack = new Stack<int>();

            string[] args = Console.ReadLine().Split(' ');

            int n = int.Parse(args[0]);
            int s = int.Parse(args[1]);
            int x = int.Parse(args[2]);

            string[] numbers = Console.ReadLine().Split(' ');

            for (int i = 0; i < numbers.Length; i++)
            {
                stack.Push(int.Parse(numbers[i]));
            }

            int length = Math.Min(stack.Count, s);
            for (int i = 0; i < length; i++)
            {
                stack.Pop();
            }

            if (stack.Count == 0)
            {
                Console.WriteLine(0);
            }
            else if (stack.Contains(x))
            {
                Console.WriteLine("true");
            }
            else
            {
                while (stack.Count > 1)
                {
                    int firstNumber = stack.Pop();
                    int secondNumber = stack.Pop();
                    stack.Push(Math.Min(firstNumber, secondNumber));
                }
                Console.WriteLine(stack.Pop());
            }
        }
    }
}
