using System;

namespace _07_ChristmasTree
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i <= n; i++)
                Console.WriteLine(
                    new string(' ', n - i) + new string('*', i) + " | " + 
                    new string('*', i) + new string(' ', n - i));            
        }
    }
}
