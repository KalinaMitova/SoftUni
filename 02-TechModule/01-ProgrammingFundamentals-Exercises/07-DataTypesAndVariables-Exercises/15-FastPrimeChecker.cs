namespace _15_FastPrimeChecker
{
    using System;

    static class FastPrimeChecker
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            for (int currentNumber = 2; currentNumber <= n; currentNumber++)
            {
                bool isPirme = true;
                for (int divider = 2; divider <= Math.Sqrt(currentNumber); divider++)
                {
                    if (currentNumber % divider == 0)
                    {
                        isPirme = false;
                        break;
                    }
                }
                Console.WriteLine($"{currentNumber} -> {isPirme}");
            }

        }
    }
}
