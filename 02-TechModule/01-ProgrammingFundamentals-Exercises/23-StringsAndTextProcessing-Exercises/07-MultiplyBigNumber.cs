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

            if (secondNumber == "" || firstNumber == "")
            {
                Console.WriteLine(0);
                return;
            }

            int length = firstNumber.Length;

            StringBuilder totalSum = new StringBuilder();
            int residue = 0;

            for (int i = 0; i < length; i++)
            {
                int curNum1 = (int)char.GetNumericValue(firstNumber[length - i - 1]);
                int curNum2 = int.Parse(secondNumber);

                string curSum = curSum = (curNum1 * curNum2 + residue).ToString();

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
