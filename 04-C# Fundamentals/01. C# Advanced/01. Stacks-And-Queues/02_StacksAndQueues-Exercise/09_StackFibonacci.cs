namespace _09_StackFibonacci
{
    using System;
    using System.Collections.Generic;

    public class StackFibonacci
    {
        public static void Main()
        {
            Stack<long> stack = new Stack<long>();

            int n = int.Parse(Console.ReadLine());

            stack.Push(0);
            stack.Push(1);
            
            for (int i = 0; i < n - 1; i++)
            {
                long firstPrevNumber = stack.Pop();
                long secondPrevNumber = stack.Pop();
                stack.Push(firstPrevNumber);
                stack.Push(firstPrevNumber + secondPrevNumber);
            }

            Console.WriteLine(stack.Peek());
        }
    }
}
