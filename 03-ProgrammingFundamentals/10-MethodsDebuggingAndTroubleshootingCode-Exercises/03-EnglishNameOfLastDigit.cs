using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_EnglishNameOfLastDigit
{
    class Program
    {
        static void Main(string[] args)
        {
            long number = long.Parse(Console.ReadLine());

            long lastDigit = GetLastDigit(number);
            string digitToWord = convertDigitToWord(lastDigit);

            Console.WriteLine(digitToWord);
        }

        static string convertDigitToWord(long lastDigit)
        {
            string toWord = string.Empty;
            switch (lastDigit)
            {
                case 0:
                    toWord = "zero";
                    break;
                case 1:
                    toWord = "one";
                    break;
                case 2:
                    toWord = "two";
                    break;
                case 3:
                    toWord = "three";
                    break;
                case 4:
                    toWord = "four";
                    break;
                case 5:
                    toWord = "five";
                    break;
                case 6:
                    toWord = "six";
                    break;
                case 7:
                    toWord = "seven";
                    break;
                case 8:
                    toWord = "eight";
                    break;
                case 9:
                    toWord = "nine";
                    break;
            }
            return toWord;
        }

        static long GetLastDigit(long number)
        {
            return Math.Abs(number) % 10;
        }
    }
}
