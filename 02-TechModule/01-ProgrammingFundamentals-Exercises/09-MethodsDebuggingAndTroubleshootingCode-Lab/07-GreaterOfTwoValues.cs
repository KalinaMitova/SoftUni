using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07_GreaterOfTwoValues
{
    class Program
    {
        static void Main(string[] args)
        {
            string type = Console.ReadLine();

            switch (type)
            {
                case "int":
                    int firstNumber = int.Parse(Console.ReadLine());
                    int secondNumber = int.Parse(Console.ReadLine());
                    Console.WriteLine(GetMax(firstNumber, secondNumber));
                    break;
                case "char":
                    char firstChar = char.Parse(Console.ReadLine());
                    char secondChar = char.Parse(Console.ReadLine());
                    Console.WriteLine(GetMax(firstChar, secondChar));
                    break;
                case "string":
                    string firstString = Console.ReadLine();
                    string SecondString = Console.ReadLine();
                    Console.WriteLine(GetMax(firstString, SecondString));
                    break;
                default:
                    Console.WriteLine("Incorrect type");
                    break;
            }
        }

        static int GetMax(int a, int b)
        {
            if (a > b)
            {
                return a;
            }
            return b;
        }

        static char GetMax(char a, char b)
        {
            if (a > b)
            {
                return a;
            }
            return b;
        }

        static string GetMax(string a, string b)
        {
            if (a.CompareTo(b) == 1)
            {
                return a;
            }
            return b;
        }
    }
}
