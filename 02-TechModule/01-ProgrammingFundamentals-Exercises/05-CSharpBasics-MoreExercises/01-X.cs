using System;

namespace _01_X
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int length = n / 2;
            int middleSpaces = n - 2;
            int leftRightSpaces = 0;

            for (int i = 0; i < length; i++)
            {
                Console.WriteLine(new string(' ', leftRightSpaces) + 'x' + new string(' ', middleSpaces) +'x' + new string(' ', leftRightSpaces));
                middleSpaces-=2;
                leftRightSpaces++;
            }

            Console.WriteLine(new string(' ', length) + 'x' + new string(' ', length));
            middleSpaces+=2;
            leftRightSpaces--;

            for (int i = 0; i < length; i++)
            {
                Console.WriteLine(new string(' ', leftRightSpaces) + 'x' + new string(' ', middleSpaces) + 'x' + new string(' ', leftRightSpaces));
                middleSpaces+=2;
                leftRightSpaces--;
            }
        }
    }
}
