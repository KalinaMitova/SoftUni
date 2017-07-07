using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08_LettersChangeNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] line = Console.ReadLine().Split()
                .Where(str => str != "")
                .Select(str => str.Trim())
                .ToArray();

            decimal totalSum = 0;

            foreach (var sequence in line)
            {
                char firstLetter = sequence.First();
                char lastLetter = sequence.Last();
                int number = int.Parse(sequence.Substring(1, sequence.Length - 2));

                int firstLetterPosition = char.ToUpper(firstLetter) - 64;
                int lastLetterPosition = char.ToUpper(lastLetter) - 64;

                decimal currentSum = 0;

                if (char.IsUpper(firstLetter))
                {
                    currentSum += number / (decimal)firstLetterPosition;
                }
                else
                {
                    currentSum += number * (decimal)firstLetterPosition;
                }

                if (char.IsUpper(lastLetter))
                {
                    currentSum -= lastLetterPosition;
                }
                else
                {
                    currentSum += lastLetterPosition;
                }

                totalSum += currentSum;
            }

            Console.WriteLine($"{totalSum:F2}");
        }
    }
}
