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
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] command = Console.ReadLine().Split();

                switch (command[0].ToLower())
                {
                    case "reverse":
                        arr = arr.Reverse().ToArray();
                        break;
                    case "distinct":
                        arr = arr.Distinct().ToArray();
                        break;
                    case "replace":
                        arr[int.Parse(command[1])] = command[2];
                        break;
                }
            }

            Console.WriteLine(String.Join(", ", arr));
        }
        
    }
}
