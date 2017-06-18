using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07_TakeSkipRope
{
    class Program
    {
        static void Main(string[] args)
        {
            var line = Console.ReadLine().ToCharArray().ToList();

            var numbers = line
                .Where(el => char.IsDigit(el))
                .Select(el => (int)char.GetNumericValue(el))
                .ToList();

            var nonNumbers = line
                .Where(el => !(char.IsDigit(el)))
                .ToList();

            var takeList = new List<int>();
            var skipList = new List<int>();

            for (int i = 0; i < numbers.Count; i++)
            {
                if (i % 2 == 0)
                {
                    takeList.Add(numbers[i]);
                }
                else
                {
                    skipList.Add(numbers[i]);
                }
            }

            var total = 0;
            var result = new List<char>();

            for (int i = 0; i < takeList.Count; i++)
            {
                result.AddRange(nonNumbers.Skip(total).Take(takeList[i]).ToList());

                total += takeList[i] + skipList[i];
            }

            Console.WriteLine(string.Join("", result));
        }
    }
}
