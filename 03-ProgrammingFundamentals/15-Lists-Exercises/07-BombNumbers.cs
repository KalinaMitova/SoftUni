using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07_BombNumbers
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

            int[] bomb =
                Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            while (numbers.IndexOf(bomb[0]) >= 0)
            {
                int startIndex = numbers.IndexOf(bomb[0]) - bomb[1];
                int endIndex = numbers.IndexOf(bomb[0]) + bomb[1];

                if (startIndex < 0)
                {
                    startIndex = 0;
                }

                if (endIndex > numbers.Count - 1)
                {
                    endIndex = numbers.Count - 1;
                }

                for (int i = startIndex; i <= endIndex; i++)
                {
                    numbers.RemoveAt(startIndex);
                }
            }

            Console.WriteLine(numbers.Sum());
        }
    }
}
