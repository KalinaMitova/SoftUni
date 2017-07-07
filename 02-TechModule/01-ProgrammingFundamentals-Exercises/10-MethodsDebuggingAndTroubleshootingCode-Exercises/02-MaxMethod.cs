using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_MaxMethod
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstNumber = int.Parse(Console.ReadLine());
            int secondNumber = int.Parse(Console.ReadLine());
            int thirdNumber = int.Parse(Console.ReadLine());

            Console.WriteLine(GetMax(firstNumber, GetMax(secondNumber, thirdNumber)));
        }

        static int GetMax(int a, int b)
        {
            if (a > b)
            {
                return a;
            }
            return b;
        }
    }
}
