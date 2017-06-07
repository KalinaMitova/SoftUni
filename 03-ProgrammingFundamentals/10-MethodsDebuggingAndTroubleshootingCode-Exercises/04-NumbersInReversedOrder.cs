using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_NumbersInReversedOrder
{
    class Program
    {
        static void Main(string[] args)
        {
            string number = Console.ReadLine();
            string reversedNumber = ReverseNumber(number);
            Console.WriteLine(reversedNumber);
        }

        static string ReverseNumber(string number)
        {
            int length = number.Length;
            string reversed = string.Empty;
            for (int i = length - 1; i >= 0; i--)
            {
                reversed += number[i];
            }
            return reversed;
        }
    }
}
