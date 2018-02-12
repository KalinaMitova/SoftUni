namespace _03_DecimalToBinaryConverter
{
    using System;
    using System.Collections.Generic;

    public class DecimalToBinaryConverter
    {
        public static void Main()
        {
            int number = int.Parse(Console.ReadLine());
            Stack<int> numbers = new Stack<int>();

            do
            {
                numbers.Push(number % 2);
                number /= 2;
            }
            while (number > 0);            

            while (numbers.Count > 0)
            {
                Console.Write(numbers.Pop());
            }
            Console.WriteLine();
        }
    }
}
