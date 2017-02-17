using System;

namespace _09_House
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int length = (n + 1) / 2;
            int roofStarts;

            if (n % 2 == 0) roofStarts = 2;
            else roofStarts = 1;

            for (int i = 0; i < length; i++)
            {
                Console.WriteLine(new string('-', length - i - 1) + new string('*', roofStarts) + new string('-', length - i - 1));                
                roofStarts += 2;                
            }

            for (int i = 0; i < n / 2; i++)
            {
                Console.WriteLine('|' + new string('*', n - 2) + '|');
            }
        }
    }
}
