using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_RemoveNegativesAndReverse
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = 
                Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            numbers.RemoveAll(p => p < 0);
            numbers.Reverse();

            if (numbers.Count > 0)
            {
                Console.WriteLine(String.Join(", ", numbers));
            }
            else
            {
                Console.WriteLine("empty");
            }
        }
    }
}
