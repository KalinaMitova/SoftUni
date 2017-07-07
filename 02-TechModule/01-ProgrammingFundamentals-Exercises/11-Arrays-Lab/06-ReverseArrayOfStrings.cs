using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06_ReverseArrayOfStrings
{
    class Program
    {
        static void Main(string[] args)
        {            
            Console.WriteLine(String.Join(" ", Console.ReadLine().Split(' ').Reverse()));
        }
    }
}
