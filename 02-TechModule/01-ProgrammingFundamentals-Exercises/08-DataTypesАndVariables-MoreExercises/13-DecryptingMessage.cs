namespace _13_DecryptingMessage
{
    using System;

    static class DecryptingMessage
    {
        static void Main()
        {
            int key = int.Parse(Console.ReadLine());
            int n = int.Parse(Console.ReadLine());

            string text = string.Empty;
            for (int i = 0; i < n; i++)
            {
                char symbol = char.Parse(Console.ReadLine());

                text += (char)(symbol + key);
            }
            Console.WriteLine(text);
        }
    }
}