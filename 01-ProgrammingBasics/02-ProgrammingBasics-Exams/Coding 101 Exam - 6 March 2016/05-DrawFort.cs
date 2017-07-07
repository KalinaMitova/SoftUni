using System;

namespace _05_DrawFort
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int width = n * 2;
            int col = n / 2;
            int mid = width - ( 4 + col * 2) < 0 ? 0 : width - (4 + col * 2);

            Console.WriteLine('/' + new string('^', col) + '\\' + new string('_', mid) + '/' + new string('^', col) + '\\');
            for (int i = 0; i < n - 2; i++)
            {
                if(i == n - 3)
                {
                    Console.WriteLine('|' + new string(' ', col + 1) + new string('_', mid) + new string(' ', col + 1) + '|');
                }                    
                else
                {
                    Console.WriteLine('|' + new string(' ', col * 2 + mid + 2) + '|');
                }
            }
            Console.WriteLine('\\' + new string('_', col) + '/' + new string(' ', mid) + '\\' + new string('_', col) + '/');
        }
    }
}
