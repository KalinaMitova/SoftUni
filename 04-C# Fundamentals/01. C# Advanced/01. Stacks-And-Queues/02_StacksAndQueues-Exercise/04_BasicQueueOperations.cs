namespace _04_BasicQueueOperations
{
    using System;
    using System.Collections.Generic;

    public class BasicQueueOperations
    {
        public static void Main()
        {
            Queue<int> queue = new Queue<int>();

            string[] args = Console.ReadLine().Split(' ');

            int n = int.Parse(args[0]);
            int s = int.Parse(args[1]);
            int x = int.Parse(args[2]);

            string[] numbers = Console.ReadLine().Split(' ');

            for (int i = 0; i < numbers.Length; i++)
            {
                queue.Enqueue(int.Parse(numbers[i]));
            }

            int length = Math.Min(queue.Count, s);
            for (int i = 0; i < length; i++)
            {
                queue.Dequeue();
            }

            if (queue.Count == 0)
            {
                Console.WriteLine(0);
            }
            else if (queue.Contains(x))
            {
                Console.WriteLine("true");
            }
            else
            {
                while (queue.Count > 1)
                {
                    int firstNumber = queue.Dequeue();
                    int secondNumber = queue.Dequeue();
                    queue.Enqueue(Math.Min(firstNumber, secondNumber));
                }
                Console.WriteLine(queue.Dequeue());
            }
        }
    }
}
