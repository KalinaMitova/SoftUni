using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_ChangeList
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers =
                Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            string[] commands = Console.ReadLine().Split();

            while (commands[0] != "Odd" && commands[0] != "Even")
            {
                if (commands[0] == "Delete")
                {
                    int element = int.Parse(commands[1]);
                    numbers.RemoveAll(p => p == element);
                }
                else if (commands[0] == "Insert")
                {
                    int element = int.Parse(commands[1]);
                    int position = int.Parse(commands[2]);
                    numbers.Insert(position, element);
                }

                commands = Console.ReadLine().Split();
            }


            for (int i = 0; i < numbers.Count; i++)
            {
                if (commands[0] == "Even" && numbers[i] % 2 == 0)
                {
                    Console.Write(numbers[i]);
                    if (i != numbers.Count - 1)
                    {
                        Console.Write(" ");
                    }
                }
                else if (commands[0] == "Odd" && numbers[i] % 2 == 1)
                {
                    Console.Write(numbers[i]);
                    if (i != numbers.Count - 1)
                    {
                        Console.Write(" ");
                    }
                }
            }
            Console.WriteLine();
        }
    }
}
