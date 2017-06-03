namespace _06_StringsAndObjects
{
    using System;

    static class Program
    {
        static void Main()
        {
            string hello = "Hello";
            string world = "World";
            object helloWorld = hello + " " + world;
            string helloWorldToString = (string)helloWorld;
            Console.WriteLine(helloWorldToString);
        }
    }
}
