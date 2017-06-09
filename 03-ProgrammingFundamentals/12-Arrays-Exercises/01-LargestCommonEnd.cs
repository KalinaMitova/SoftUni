using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_LargestCommonEnd
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] firstArr = Console.ReadLine().Split(' ');
            string[] secondArr = Console.ReadLine().Split(' ');

            int shorter = Math.Min(firstArr.Length, secondArr.Length);

            int leftToRightCounter = 0;
            int rightToLeftCounter = 0;

            for (int i = 0; i < shorter; i++)
            {
                if (firstArr[i] == secondArr[i])
                {
                    leftToRightCounter++;
                }

                if (firstArr[firstArr.Length - i - 1] == secondArr[secondArr.Length - i - 1])
                {
                    rightToLeftCounter++;
                }
            }

            Console.WriteLine(Math.Max(leftToRightCounter, rightToLeftCounter));
        }
    }
}
