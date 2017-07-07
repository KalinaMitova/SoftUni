using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05_ArrayManipulator
{
    class Program
    {
        static void Main(string[] args)
        {
            List<long> numbers =
                Console.ReadLine()
                .Split()
                .Select(long.Parse)
                .ToList();

            string[] commands = Console.ReadLine().Split();

            while (commands[0] != "print")
            {
                string baseCommand = commands[0];

                if (baseCommand == "add")
                {
                    int index = int.Parse(commands[1]);
                    int element = int.Parse(commands[2]);

                    numbers.Insert(index, element);
                }
                else if (baseCommand == "addMany")
                {
                    int index = int.Parse(commands[1]);
                    for (int i = commands.Length - 1; i > 1; i--)
                    {
                        int element = int.Parse(commands[i]);
                        numbers.Insert(index, element);
                    }
                }
                else if (baseCommand == "contains")
                {
                    int element = int.Parse(commands[1]);
                    Console.WriteLine(numbers.IndexOf(element));
                }
                else if (baseCommand == "remove")
                {
                    int index = int.Parse(commands[1]);
                    numbers.RemoveAt(index);
                }
                else if (baseCommand == "shift")
                {
                    int positions = int.Parse(commands[1]);

                    for (int i = 0; i < positions; i++)
                    {
                        numbers.Add(numbers[0]);
                        numbers.RemoveAt(0);
                    }
                }
                else if (baseCommand == "sumPairs")
                {
                    for (int i = 0; i < numbers.Count; i++)
                    {
                        if (i + 1 < numbers.Count)
                        {
                            numbers[i] += numbers[i + 1];
                            numbers.RemoveAt(i + 1);
                        }
                    }
                }

                commands = Console.ReadLine().Split();
            }

            Console.WriteLine($"[{String.Join(", ", numbers)}]");
        }
    }
}
