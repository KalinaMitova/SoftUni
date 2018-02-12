namespace _11_PoisonousPlants
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    public class PoisonousPlants
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            int[] plants = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int[] days = new int[n];
            Stack<int> proxmityStack = new Stack<int>();

            for (int i = 0; i < n; i++)
            {
                int maxDays = 0;
                while (proxmityStack.Count > 0 && plants[proxmityStack.Peek()] >= plants[i] )
                {
                    maxDays = Math.Max(maxDays, days[proxmityStack.Pop()]);
                }
                if(proxmityStack.Count > 0)
                {
                    days[i] = maxDays + 1;
                }
                proxmityStack.Push(i);
            }
            Console.WriteLine(days.Max());
        }
    }
}
