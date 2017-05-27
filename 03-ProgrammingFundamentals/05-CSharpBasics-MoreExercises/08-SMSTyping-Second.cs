using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            string text = string.Empty;

            for (int i = 0; i < n; i++)
            {
                string number = Console.ReadLine();
                int mainNumber = int.Parse(number[0].ToString());
                int numberOfDigits = number.Length;
                int offset = (mainNumber - 2) * 3;

                if (mainNumber == 8 || mainNumber == 9)
                {
                    offset++;
                }

                if (mainNumber == 0)
                {
                    text += ' ';
                }
                else
                {
                    text += (char)(97 + offset + numberOfDigits - 1);
                }
            }

            Console.WriteLine(text);
        }
    }
}
