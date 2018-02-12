namespace _08_RecursiveFibonacci
{
    using System;

    public class RecursiveFibonacci
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            long prevNumber = 0;
            long fibonacci = 1;

            for (int i = 0; i < n - 1; i++)
            {
                long currentFib = fibonacci;
                fibonacci += prevNumber;
                prevNumber = currentFib;
            }

            Console.WriteLine(fibonacci);
        }
    }
}
