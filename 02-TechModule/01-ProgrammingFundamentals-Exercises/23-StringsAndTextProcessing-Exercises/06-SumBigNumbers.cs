using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06_SumBigNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            string firstNumber = Console.ReadLine().TrimStart('0');
            string secondNumber = Console.ReadLine().TrimStart('0');

            int length = Math.Max(firstNumber.Length, secondNumber.Length);

            StringBuilder totalSum = new StringBuilder(length + 1);
            int residue = 0;

            for (int i = 0; i < length; i++)
            {
                int curNum1 = (int)char.GetNumericValue(firstNumber[firstNumber.Length - (i % firstNumber.Length) - 1]);
                int curNum2 = (int)char.GetNumericValue(secondNumber[secondNumber.Length - (i % secondNumber.Length) - 1]);

                string curSum = "";
                if (i > secondNumber.Length - 1)
                {
                    curSum = (curNum1 + residue).ToString();
                }
                else if (i > firstNumber.Length - 1)
                {
                    curSum = (curNum2 + residue).ToString();
                }
                else
                {
                    curSum = (curNum1 + curNum2 + residue).ToString();
                }

                totalSum.Append(curSum.Last());

                if (curSum.Length != 1)
                {
                    residue = (int)char.GetNumericValue(curSum.First());
                }
                else
                {
                    residue = 0;
                }

                if (i == length - 1 && residue != 0)
                {
                    totalSum.Append(residue.ToString());
                }
            }

            Console.WriteLine(new string(totalSum.ToString().Reverse().ToArray()));
        }
    }
}
