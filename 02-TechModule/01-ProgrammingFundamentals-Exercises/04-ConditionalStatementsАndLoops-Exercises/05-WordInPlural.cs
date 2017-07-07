using System;

namespace _05_WordInPlural
{
    class Program
    {
        static void Main(string[] args)
        {
            string noun = Console.ReadLine();
            string[] cases = { "y", "o", "ch", "s", "sh", "x", "z" };

            foreach (string endCase in cases)
            {
                if (noun.EndsWith(endCase) && endCase == "y")
                {
                    Console.WriteLine(noun.Remove(noun.Length - 1) + "ies");
                    return;
                }
                else if (noun.EndsWith(endCase))
                {
                    Console.WriteLine(noun + "es");
                    return;
                }
            }

            Console.WriteLine(noun + 's');
        }
    }
}
