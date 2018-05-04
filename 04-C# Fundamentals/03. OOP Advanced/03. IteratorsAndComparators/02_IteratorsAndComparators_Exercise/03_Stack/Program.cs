using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_Stack
{
    public class Program
    {
        public static void Main()
        {
            Stack<int> stack = new Stack<int>();

            string input;
            while ((input = Console.ReadLine()) != "END")
            {
                string[] tokens = input.Split(", ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                string command = tokens[0];

                try
                {
                    switch (command)
                    {
                        case "Push":
                            int[] numbers = tokens.Skip(1).Select(int.Parse).ToArray();
                            stack.Push(numbers);
                            break;
                        case "Pop":
                            stack.Pop();
                            break;
                    }
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            foreach (var element in stack)
            {
                Console.WriteLine(element);
            }
            foreach (var element in stack)
            {
                Console.WriteLine(element);
            }
        }
    }
}
