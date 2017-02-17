using System;

namespace _05_Stop
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int length = n * 2;
            int counter = 0;

            Console.WriteLine(new string('.', n + 1) + new string('_', length + 1) + new string('.', n + 1));
            for (int i = 0; i < length + 1; i++)
            {
                if (i < (length + 1) / 2)
                {
                    Console.WriteLine(new string('.', n - i) + "//" + new string('_', length + counter - 1) + "\\\\" + new string('.', n - i));
                }
                else if (i == (length + 1) / 2)
                {
                    Console.WriteLine("//" + new string('_', length - 3) + "STOP!" + new string('_', length - 3) + "\\\\"); counter = 0;
                }
                else if (i > (length + 1) / 2)
                {
                    Console.WriteLine(new string('.', i - n - 1) + "\\\\" + new string('_', length * 2 + 1 - counter) + "//" + new string('.', i - n - 1));
                }
                counter += 2;
            }
        }
    }
}
