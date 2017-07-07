using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_SearchForANumber
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

            int[] commands =
                Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int takeElements = commands[0];
            int deleteElements = commands[1];
            int searchElement = commands[2];

            numbers = numbers.Take(takeElements).ToList();
            numbers.RemoveRange(0, deleteElements);

            if (numbers.IndexOf(searchElement) == -1)
            {
                Console.WriteLine("NO!");
            }
            else
            {
                Console.WriteLine("YES!");
            }
        }
    }
}
