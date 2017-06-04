namespace _02_NumberChecker
{
    using System;

    static class NumberChecker
    {
        static void Main()
        {
            decimal numberToCheck = decimal.Parse(Console.ReadLine());

            if (numberToCheck % 1 == 0)
            {
                Console.WriteLine("integer");
            }
            else
            {
                Console.WriteLine("floating-point");
            }
        }
    }
}
