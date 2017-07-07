using System;

namespace _04_GameOfIntervals
{
    class Program
    {
        static void Main(string[] args)
        {
            int length = int.Parse(Console.ReadLine());

            double result = 0.0;
            int counter1 = 0;
            int counter2 = 0;
            int counter3 = 0;
            int counter4 = 0;
            int counter5 = 0;
            int counter6 = 0;

            for (int i = 0; i < length; i++)
            {
                int number = int.Parse(Console.ReadLine());

                if (number >= 0 && number <= 9)
                {
                    result += number * 0.2;
                    counter1++;
                }
                else if (number >= 10 && number <= 19)
                {
                    result += number * 0.3;
                    counter2++;
                }
                else if (number >= 20 && number <= 29)
                {
                    result += number * 0.4;
                    counter3++;
                }
                else if (number >= 30 && number <= 39)
                {
                    result += 50;
                    counter4++;
                }
                else if (number >= 40 && number <= 50)
                {
                    result += 100;
                    counter5++;
                }
                else
                {
                    result /= 2;
                    counter6++;
                }
            }

            Console.WriteLine("{0:F2}", result);
            Console.WriteLine("From 0 to 9: {0:F2}%", 100.0 * counter1 / length);
            Console.WriteLine("From 10 to 19: {0:F2}%", 100.0 * counter2 / length);
            Console.WriteLine("From 20 to 29: {0:F2}%", 100.0 * counter3 / length);
            Console.WriteLine("From 30 to 39: {0:F2}%", 100.0 * counter4 / length);
            Console.WriteLine("From 40 to 50: {0:F2}%", 100.0 * counter5 / length);
            Console.WriteLine("Invalid numbers: {0:F2}%", 100.0 * counter6 / length);
        }
    }
}
