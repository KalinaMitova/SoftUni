using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_HelloName
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();

            GreetingByName(name);
        }

        static void GreetingByName(string name)
        {
            Console.WriteLine($"Hello, {name}!");
        }
    }
}
