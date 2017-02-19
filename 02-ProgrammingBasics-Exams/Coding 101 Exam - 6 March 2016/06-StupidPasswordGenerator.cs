using System;

namespace _06_StupidPasswordGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int l = int.Parse(Console.ReadLine());
            string stupidPasswords = "";

            for (int firstSymbol = 1; firstSymbol <= n; firstSymbol++)
            {
                for (int secondSymbol = 1; secondSymbol <= n; secondSymbol++)
                {
                    for (char thirdSymbol = 'a'; thirdSymbol < 'a' + l; thirdSymbol++)
                    {
                        for (char fourthSymbol = 'a'; fourthSymbol < 'a' + l; fourthSymbol++)
                        {
                            for (int fifthSymbol = Math.Max(firstSymbol, secondSymbol) + 1; fifthSymbol <= n; fifthSymbol++)
                            {
                                Console.Write("{0}{1}{2}{3}{4} ", firstSymbol, secondSymbol, thirdSymbol, fourthSymbol, fifthSymbol);
                            }
                        }
                    }
                }
            }
            Console.WriteLine();
        }
    }
}
