using System;

namespace _16_NumberZero_OneHundredToText
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            string decimalNum = "";
            string output = "";

            if (number < 0 || number > 100)
            {
                Console.WriteLine("invalid number");
                return;
            }

            if (number > 9 && number < 20)
            {
                switch (number)
                {
                    case 10: output = "ten"; break;
                    case 11: output = "eleven"; break;
                    case 12: output = "twelve"; break;
                    case 13: output = "thirteen"; break;
                    case 14: output = "fourteen"; break;
                    case 15: output = "fifteen"; break;
                    case 16: output = "sixteen"; break;
                    case 17: output = "seventeen"; break;
                    case 18: output = "eighteen"; break;
                    case 19: output = "nineteen"; break;
                }
            }
            else if (number == 100)
            {
                output = "one hundred";
            }
            else
            {
                switch (number % 10)
                {
                    case 0: decimalNum = "zero"; break;
                    case 1: decimalNum = "one"; break;
                    case 2: decimalNum = "two"; break;
                    case 3: decimalNum = "three"; break;
                    case 4: decimalNum = "four"; break;
                    case 5: decimalNum = "five"; break;
                    case 6: decimalNum = "six"; break;
                    case 7: decimalNum = "seven"; break;
                    case 8: decimalNum = "eight"; break;
                    case 9: decimalNum = "nine"; break;
                }

                if (number >= 20 && number < 100)
                {
                    int current = number / 10;
                    switch (current)
                    {
                        case 2: output = "twenty"; break;
                        case 3: output = "thirty"; break;
                        case 4: output = "fourty"; break;
                        case 5: output = "fifty"; break;
                        case 6: output = "sixty"; break;
                        case 7: output = "seventy"; break;
                        case 8: output = "eighty"; break;
                        case 9: output = "ninety"; break;
                    }

                    if (decimalNum != "zero")
                    {
                        output += " " + decimalNum;
                    }
                }
                else
                {
                    output = decimalNum;
                }
            }

            Console.WriteLine(output);
        }
    }
}