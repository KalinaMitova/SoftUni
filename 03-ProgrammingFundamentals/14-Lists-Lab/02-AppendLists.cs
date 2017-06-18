using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_AppendLists
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> sublists = Console.ReadLine().Split('|').ToList();

            List<string> result = new List<string>();

            for (int i = sublists.Count - 1; i >= 0; i--)
            {
                List<string> currentNumbers = sublists[i].Split().ToList();

                for (int j = 0; j < currentNumbers.Count; j++)
                {
                    if (currentNumbers[j] != string.Empty)
                    {
                        result.Add(currentNumbers[j]);
                    }
                }
            }

            Console.WriteLine(String.Join(" ", result));
        }
    }
}
