namespace _09_ReversedChars
{
    using System;

    static class ReversedChars
    {
        static void Main()
        {
            char a = char.Parse(Console.ReadLine());
            char b = char.Parse(Console.ReadLine());
            char c = char.Parse(Console.ReadLine());

            Console.WriteLine($"{c}{b}{a}");
        }
    }
}
