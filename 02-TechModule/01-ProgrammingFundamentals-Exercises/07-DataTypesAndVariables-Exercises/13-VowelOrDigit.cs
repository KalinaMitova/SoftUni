namespace _13_VowelOrDigit
{
    using System;

    static class VowelOrDigit
    {
        static void Main()
        {
            char symbol = char.Parse(Console.ReadLine());

            if (char.IsDigit(symbol))
            {
                Console.WriteLine("digit");
                return;
            }

            switch (symbol)
            {
                case 'a':
                case 'e':
                case 'o':
                case 'u':
                case 'i':
                case 'y':
                case 'w':
                    Console.WriteLine("vowel");
                    break;
                default:
                    Console.WriteLine("other");
                    break;
            }
        }
    }
}
