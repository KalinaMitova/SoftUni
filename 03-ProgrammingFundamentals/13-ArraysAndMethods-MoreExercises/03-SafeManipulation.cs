using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_ManipulateArray
{
    class Program
    {
        static void Main()
        {
            string[] arr = Console.ReadLine().Split();

            string[] command = Console.ReadLine().Split();

            while(command[0] != "END")
            {                
                switch (command[0])
                {
                    case "Reverse":
                        arr = arr.Reverse().ToArray();
                        break;
                    case "Distinct":
                        arr = arr.Distinct().ToArray();
                        break;
                    case "Replace":
                        int index = int.Parse(command[1]);
                        if (index >= arr.Length || index < 0)
                        {
                            Console.WriteLine("Invalid input!");
                        }
                        else
                        {
                            arr[index] = command[2];
                        }
                        break;
                    default:
                        Console.WriteLine("Invalid input!");
                        break;
                }

                command = Console.ReadLine().Split();
            }

            Console.WriteLine(String.Join(", ", arr));
        }

    }
}
