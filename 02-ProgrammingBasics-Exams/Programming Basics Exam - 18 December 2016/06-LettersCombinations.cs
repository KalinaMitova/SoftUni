using System;

namespace _06_LettersCombinations
{
    class Program
    {
        static void Main(string[] args)
        {
            char start;
            char end;

            do
            {
                start = char.Parse(Console.ReadLine());
                end = char.Parse(Console.ReadLine());
            } while (start > end);

            char stop = char.Parse(Console.ReadLine());
            int counter = 0;

            for (char i = start; i <= end; i++)
            {
                for (char j = start; j <= end; j++)
                {
                    for (char k = start; k <= end; k++)
                    {
                        if (i != stop && j != stop && k != stop)
                        {
                            Console.Write("{0}{1}{2} ", i, j, k);
                            counter++;
                        }                                
                    }                                              
                }
            }
            Console.WriteLine(counter);
        }
    }
}
