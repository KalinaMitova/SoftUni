using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07_PlayCatch
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

            var counter = 0;

            while (counter < 3)
            {
                var tokens = Console.ReadLine().Split();

                var command = tokens[0];

                switch (command)
                {
                    case "Replace":
                        {
                            try
                            {
                                var index = int.Parse(tokens[1]);
                                var element = int.Parse(tokens[2]);

                                try
                                {
                                    numbers[index] = element;
                                }
                                catch (Exception)
                                {
                                    counter++;
                                    Console.WriteLine("The index does not exist!");
                                }
                            }
                            catch (Exception)
                            {
                                counter++;
                                Console.WriteLine("The variable is not in the correct format!");
                            }
                        }
                        break;
                    case "Print":
                        {
                            try
                            {
                                var startIndex = int.Parse(tokens[1]);
                                var endIndex = int.Parse(tokens[2]);

                                string output = string.Empty;

                                try
                                {
                                    for (int i = startIndex; i <= endIndex; i++)
                                    {
                                        output += numbers[i];
                                        if (i != endIndex)
                                        {
                                            output += ", ";
                                        }
                                    }

                                    Console.WriteLine(output);
                                }
                                catch (Exception)
                                {
                                    counter++;
                                    Console.WriteLine("The index does not exist!");
                                }
                            }
                            catch (Exception)
                            {
                                counter++;
                                Console.WriteLine("The variable is not in the correct format!");
                            }                        
                        }
                        break;
                    case "Show":
                        {
                            try
                            {
                                var index = int.Parse(tokens[1]);

                                try
                                {
                                    Console.WriteLine(numbers[index]);
                                }
                                catch (Exception)
                                {
                                    counter++;
                                    Console.WriteLine("The index does not exist!");
                                }
                            }
                            catch (Exception)
                            {
                                counter++;
                                Console.WriteLine("The variable is not in the correct format!");
                            }

                        }
                        break;
                }                
            }

            Console.WriteLine(string.Join(", ", numbers));
        }
    }
}
