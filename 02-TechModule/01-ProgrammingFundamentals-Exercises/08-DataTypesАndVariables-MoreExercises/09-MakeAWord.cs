namespace _09_MakeAWord
{
    using System;

    static class MakeAWord
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            string text = string.Empty;
            for (int i = 0; i < n; i++)
            {
                char symbol = char.Parse(Console.ReadLine());

                text += symbol;
            }

            Console.WriteLine($"The word is: {text}");
        }
    }
}
