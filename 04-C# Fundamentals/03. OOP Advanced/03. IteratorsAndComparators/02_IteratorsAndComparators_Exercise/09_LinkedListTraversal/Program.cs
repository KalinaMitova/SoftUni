using System;

namespace _09_LinkedListTraversal
{
    public class Program
    {
        public static void Main()
        {
            LinekdList<int> list = new LinekdList<int>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split();
                string command = input[0];
                int item = int.Parse(input[1]);

                switch (command)
                {
                    case "Add":
                        list.Add(item);
                        break;
                    case "Remove":
                        list.Remove(item);
                        break;
                }
            }

            Console.WriteLine(list.Count);
            Console.WriteLine(string.Join(" ", list));
        }
    }
}
