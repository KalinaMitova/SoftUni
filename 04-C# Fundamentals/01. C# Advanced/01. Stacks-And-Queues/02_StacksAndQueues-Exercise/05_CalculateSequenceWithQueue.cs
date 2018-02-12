namespace _05_CalculateSequenceWithQueue
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class SequenceWithQueue
    {
        public static void Main()
        {
            Queue<long> numbers = new Queue<long>();

            long n = long.Parse(Console.ReadLine());
            numbers.Enqueue(n);

            StringBuilder output = new StringBuilder();
            for (int i = 0; i < 50; i++)
            {
                long num = numbers.Dequeue();
                numbers.Enqueue(num + 1);
                numbers.Enqueue((2 * num) + 1);
                numbers.Enqueue(num + 2);
                output.Append(num + " ");
            }

            Console.WriteLine(output.ToString());
        }
    }
}
