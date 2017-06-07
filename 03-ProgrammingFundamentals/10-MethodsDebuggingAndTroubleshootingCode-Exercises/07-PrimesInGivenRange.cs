using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06_PrimeChecker
{
    class Program
    {
        static void Main(string[] args)
        {
            int startNum = int.Parse(Console.ReadLine());
            int endNum = int.Parse(Console.ReadLine());

            if (startNum > endNum)
            {
                Console.WriteLine("(empty list)");
                return;
            }

            List<int> primeNumbersInRange = FindPrimesInRange(startNum, endNum);
            string primeNumbers = PrintList(primeNumbersInRange);

            Console.WriteLine(primeNumbers);
        }

        static string PrintList(List<int> primeNumbers)
        {
            if (primeNumbers.Count == 0)
            {
                return "(empty list)";
            }

            string output = string.Empty;
            foreach (var primeNumber in primeNumbers)
            {
                output += primeNumber + ", ";                
            }
            output = output.Remove(output.Length - 2);
            return output;
        }

        static List<int> FindPrimesInRange(int startNum, int endNum)
        {
            List<int> primeNumbers = new List<int>();

            for (int i = startNum; i <= endNum; i++)
            {
                int currentNumber = i;
                bool isPrime = true;

                if (currentNumber == 0 || currentNumber == 1)
                {
                    isPrime = false;
                }

                for (int divider = 2; divider <= Math.Sqrt(currentNumber); divider++)
                {
                    if (currentNumber % divider == 0)
                    {
                        isPrime = false;
                    }
                }

                if (isPrime)
                {
                    primeNumbers.Add(currentNumber);
                }
            }

            return primeNumbers;
        }
    }
}
