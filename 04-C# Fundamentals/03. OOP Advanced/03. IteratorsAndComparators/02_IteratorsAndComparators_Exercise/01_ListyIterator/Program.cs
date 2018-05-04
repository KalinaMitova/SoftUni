using System;
using System.Linq;
using System.Collections.Generic;

namespace _01_ListyIterator
{
    public class Program
    {
        public static void Main()
        {
            string[] createCommand = Console.ReadLine().Split();
            List<string> args = createCommand.Skip(1).ToList();

            ListyIterator<string> listy = new ListyIterator<string>(args);

            string input;
            while ((input = Console.ReadLine()) != "END")
            {
                string[] tokens = input.Split();
                string command = tokens[0];

                try
                {
                    switch (command)
                    {
                        case "Move":
                            Console.WriteLine(listy.Move());
                            break;
                        case "HasNext":
                            Console.WriteLine(listy.HasNext());
                            break;
                        case "Print":
                            listy.Print();
                            break;
                    }
                }
                catch (InvalidOperationException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
