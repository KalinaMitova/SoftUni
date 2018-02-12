namespace _10_SimpleTextEditor
{
    using System;
    using System.Collections.Generic;

    public class SimpleTextEditor
    {
        public static void Main()
        {
            Stack<string> history = new Stack<string>();

            int n = int.Parse(Console.ReadLine());

            string text = string.Empty;
            history.Push(text);

            for (int i = 0; i < n; i++)
            {
                string[] command = Console.ReadLine().Split();

                switch (command[0])
                {
                    case "1":
                        history.Push(text);
                        string currentText = command[1];
                        text += currentText;
                        break;
                    case "2":
                        history.Push(text);
                        int length = int.Parse(command[1]);
                        int startIndex = text.Length - length;
                        text = text.Remove(startIndex, length);
                        break;
                    case "3":
                        int index = int.Parse(command[1]) - 1;
                        Console.WriteLine(text[index]);
                        break;
                    case "4":
                        text = history.Pop();
                        break;
                }
            }
        }
    }
}
