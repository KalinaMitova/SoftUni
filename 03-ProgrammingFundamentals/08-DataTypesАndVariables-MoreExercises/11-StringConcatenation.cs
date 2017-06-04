namespace _11_StringConcatenation
{
    using System;

    static class StringConcatenation
    {
        static void Main()
        {
            char delimiter = char.Parse(Console.ReadLine());
            string oddOrEven = Console.ReadLine();
            int n = int.Parse(Console.ReadLine());

            string text = string.Empty;            
            for (int i = 1; i <= n; i++)
            {
                string word = Console.ReadLine();

                if (oddOrEven == "even" && i % 2 == 0)
                {
                    text += word + delimiter;
                }
                if (oddOrEven == "odd" && i % 2 != 0)
                {
                    text += word + delimiter;
                }
            }

            text = text.Remove(text.Length - 1);

            Console.WriteLine(text);
        }
    }
}
