namespace _07_ExchangeVariableValues
{
    using System;

    static class ExchangeVariableValues
    {
        static void Main()
        {
            int a = 5;
            int b = 10;

            Console.WriteLine("Before:");
            Console.WriteLine("a = {0}", a);
            Console.WriteLine("b = {0}", b);

            a += b;
            b = a - b;
            a = a - b;

            Console.WriteLine("After:");
            Console.WriteLine("a = {0}", a);
            Console.WriteLine("b = {0}", b);
        }
    }
}
