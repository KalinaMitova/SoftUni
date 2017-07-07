namespace _14_IntegerToHexAndBinary
{
    using System;

    static class IntegerToHexAndBinary
    {
        static void Main()
        {
            int number = int.Parse(Console.ReadLine());

            Console.WriteLine(Convert.ToString(number, 16).ToUpper());
            Console.WriteLine(Convert.ToString(number, 2));
        }
    }
}
