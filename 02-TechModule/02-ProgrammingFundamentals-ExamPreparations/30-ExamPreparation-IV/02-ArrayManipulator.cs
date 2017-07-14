using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_ArrayManipulator
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = Console.ReadLine().Split().Select(int.Parse).ToArray();

            string line = Console.ReadLine();
            while (line != "end")
            {
                string[] tokens = line.Split();
                string command = tokens[0];
                
                if (command == "exchange")
                {
                    var splitIndex = int.Parse(tokens[1]);

                    if (splitIndex >= 0 && splitIndex <= array.Length - 1)
                    {
                        int[] leftSide = array.Take(splitIndex + 1).ToArray();
                        int[] rightSide = array.Skip(splitIndex + 1).Take(array.Length - splitIndex + 1).ToArray();
                        array = rightSide.Concat(leftSide).ToArray();
                    }
                    else
                    {
                        Console.WriteLine("Invalid index");
                    }

                    
                }
                else if (command == "max")
                {
                    string oddOrEven = tokens[1];
                    if (oddOrEven == "odd")
                    {
                        int[] oddNumbers = array.Where(n => n % 2 == 1).ToArray();
                        if (oddNumbers.Length > 0)
                        {
                            var maxOdd = oddNumbers.Max();
                            int maxOddIndex = Array.LastIndexOf(array, maxOdd);
                            Console.WriteLine(maxOddIndex);
                        }
                        else
                        {
                            Console.WriteLine("No matches");
                        }
                    }
                    else if (oddOrEven == "even")
                    {
                        int[] evenNumbers = array.Where(n => n % 2 == 0).ToArray();
                        if (evenNumbers.Length > 0)
                        {
                            var maxEven = evenNumbers.Max();
                            int maxEvenIndex = Array.LastIndexOf(array, maxEven);
                            Console.WriteLine(maxEvenIndex);
                        }
                        else
                        {
                            Console.WriteLine("No matches");
                        }
                    }
                }
                else if (command == "min")
                {
                    string oddOrEven = tokens[1];
                    if (oddOrEven == "odd")
                    {
                        int[] oddNumbers = array.Where(n => n % 2 == 1).ToArray();
                        if (oddNumbers.Length > 0)
                        {
                            var maxOdd = oddNumbers.Min();
                            int maxOddIndex = Array.LastIndexOf(array, maxOdd);
                            Console.WriteLine(maxOddIndex);
                        }
                        else
                        {
                            Console.WriteLine("No matches");
                        }
                    }
                    else if (oddOrEven == "even")
                    {
                        int[] evenNumbers = array.Where(n => n % 2 == 0).ToArray();
                        if (evenNumbers.Length > 0)
                        {
                            var maxEven = evenNumbers.Min();
                            int maxEvenIndex = Array.LastIndexOf(array, maxEven);
                            Console.WriteLine(maxEvenIndex);
                        }
                        else
                        {
                            Console.WriteLine("No matches");
                        }
                    }
                }
                else if (command == "first")
                {
                    int count = int.Parse(tokens[1]);
                    string oddOrEven = tokens[2];

                    if (count > 0 && count <= array.Length)
                    {
                        if (oddOrEven == "odd")
                        {
                            int[] oddNumbers = array.Where(n => n % 2 == 1).Take(count).ToArray();
                            Console.WriteLine($"[{string.Join(", ", oddNumbers)}]");
                        }
                        else
                        {
                            int[] evenNumbers = array.Where(n => n % 2 == 0).Take(count).ToArray();
                            Console.WriteLine($"[{string.Join(", ", evenNumbers)}]");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid count");
                    }

                }
                else if (command == "last")
                {
                    int count = int.Parse(tokens[1]);
                    string oddOrEven = tokens[2];

                    if (count > 0 && count <= array.Length)
                    {
                        if (oddOrEven == "odd")
                        {
                            int[] oddNumbers = array.Where(n => n % 2 == 1).Reverse().Take(count).Reverse().ToArray();
                            Console.WriteLine($"[{string.Join(", ", oddNumbers)}]");
                        }
                        else
                        {
                            int[] evenNumbers = array.Where(n => n % 2 == 0).Reverse().Take(count).Reverse().ToArray();
                            Console.WriteLine($"[{string.Join(", ", evenNumbers)}]");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid count");
                    }                    
                }

                line = Console.ReadLine();
            }

            Console.WriteLine($"[{string.Join(", ", array)}]");
        }
    }
}
