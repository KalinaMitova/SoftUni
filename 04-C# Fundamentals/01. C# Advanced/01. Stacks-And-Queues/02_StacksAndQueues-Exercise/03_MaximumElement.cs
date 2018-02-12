namespace _03_MaximumElement
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class MaximumElement
    {
        public static void Main()
        {
            Stack<int> numbers = new Stack<int>();
            Stack<int> maxNumbers = new Stack<int>();
            
            int n = int.Parse(Console.ReadLine());

            int maxNumber = int.MinValue;
            maxNumbers.Push(maxNumber);

            for (int i = 0; i < n; i++)
            {
                string[] args = Console.ReadLine().Split(' ');
                int command = int.Parse(args[0]);

                if (command == 1)
                {
                    int number = int.Parse(args[1]);
                    numbers.Push(number);
                    if(number > maxNumber)
                    {
                        maxNumber = number;
                        maxNumbers.Push(maxNumber);
                    }
                }
                else if (command == 2 && numbers.Count > 0)
                {
                    if(numbers.Pop() == maxNumber)
                    {
                        maxNumbers.Pop();
                        maxNumber = maxNumbers.Peek();
                    }
                }
                else if (command == 3)
                {
                    Console.WriteLine(maxNumber);
                }
            }
        }
    }
}
