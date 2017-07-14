using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_PokemonDon_tGo
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> sequence = Console.ReadLine()
                .Split(new char[] { }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            int totalSum = 0;

            while (sequence.Count > 0)
            {
                int index = int.Parse(Console.ReadLine());
                int removedNumber;

                if (index < 0)
                {
                    removedNumber = sequence.First();
                    totalSum += removedNumber;
                    sequence.RemoveAt(0);
                    sequence.Insert(0, sequence[sequence.Count - 1]);
                }
                else if (index > sequence.Count - 1)
                {
                    removedNumber = sequence.Last();
                    totalSum += removedNumber;
                    sequence.RemoveAt(sequence.Count - 1);
                    sequence.Add(sequence.First());
                }
                else
                {
                    removedNumber = sequence[index];
                    totalSum += removedNumber;
                    sequence.RemoveAt(index);                    
                }

                for (int i = 0; i < sequence.Count; i++)
                {
                    int currentNumber = sequence[i];
                    if (currentNumber <= removedNumber)
                    {
                        sequence[i] += removedNumber;
                    }
                    else
                    {
                        sequence[i] -= removedNumber;
                    }
                }
            }
            Console.WriteLine(totalSum);
        }
    }
}
