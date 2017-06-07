using System;

public class Substring_broken
{
    public static void Main()
    {
        string text = Console.ReadLine();
        int jump = int.Parse(Console.ReadLine());

        char searchChar = 'p';
        bool hasMatch = false;

        for (int i = 0; i < text.Length; i++)
        {
            if (text[i] == searchChar)
            {
                hasMatch = true;

                int length = jump + 1;

                if (length + i > text.Length)
                {
                    length = text.Length - i;
                }

                string matchedString = text.Substring(i, length);
                Console.WriteLine(matchedString);
                i += jump;
            }
        }

        if (!hasMatch)
        {
            Console.WriteLine("no");
        }
    }
}
