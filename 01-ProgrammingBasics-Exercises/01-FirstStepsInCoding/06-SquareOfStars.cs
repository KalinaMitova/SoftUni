using System;

namespace FirstStepsInCoding
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());

            if(n <= 1)
            {
                Console.WriteLine(new string('*', n));
            }
            else
            {
                Console.WriteLine(new string('*', n));

                for (int i = 1; i <= n - 2; i++)
                {
                    Console.WriteLine('*' + new string(' ', n - 2) + '*');
                }

                Console.WriteLine(new string('*', n));
            }
        }
    }
}