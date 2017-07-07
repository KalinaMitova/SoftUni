namespace ReverseString
{
    using System;
    using System.Linq;

    class Program
    {
        static void Main()
        {
            var text = Console.ReadLine();

            Console.WriteLine(new string(text.Reverse().ToArray()));
        }
    }
}
