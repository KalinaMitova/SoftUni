using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_CommandInterpreter
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> collection = Console.ReadLine()
                .Split(new char[] { }, StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            string line = Console.ReadLine();
            while (line != "end")
            {
                string[] tokens = line.Split();
                string command = tokens[0];

                if (command == "reverse")
                {
                    int start = int.Parse(tokens[2]);
                    int count = int.Parse(tokens[4]);

                    if(start >= 0 && start < collection.Count && count >= 0 && start + count <= collection.Count)
                    {
                        collection.Reverse(start, count);
                    }
                    else
                    {
                        Console.WriteLine("Invalid input parameters.");
                    }

                }
                else if (command == "sort")
                {
                    int start = int.Parse(tokens[2]);
                    int count = int.Parse(tokens[4]);

                    if (start >= 0 && start < collection.Count && count >= 0 && start + count <= collection.Count)
                    {
                        collection.Sort(start, count, Comparer<string>.Default);
                    }
                    else
                    {
                        Console.WriteLine("Invalid input parameters.");
                    }

                }
                else if (command == "rollLeft")
                {
                    int count = int.Parse(tokens[1]);
                    
                    if (count >= 0)
                    {
                        var length = count % collection.Count;
                        for (int i = 0; i < length; i++)
                        {
                            var firsElement = collection.First();
                            collection.RemoveAt(0);
                            collection.Add(firsElement);
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid input parameters.");
                    }

                }
                else if (command == "rollRight")
                {
                    int count = int.Parse(tokens[1]);

                    if (count >= 0)
                    {
                        var length = count % collection.Count;
                        for (int i = 0; i < length; i++)
                        {
                            var lastElement = collection.Last();
                            collection.RemoveAt(collection.Count - 1);
                            collection.Insert(0, lastElement);
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid input parameters.");
                    }                    
                }

                line = Console.ReadLine();
            }

            Console.WriteLine($"[{string.Join(", ", collection)}]");
        }        
    }
}
