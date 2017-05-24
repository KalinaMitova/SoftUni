using System;

namespace _01_DebitCardNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstNumbers = int.Parse(Console.ReadLine());
            int secondNumbers = int.Parse(Console.ReadLine());
            int thirdNumbers = int.Parse(Console.ReadLine());
            int fourthNumbers = int.Parse(Console.ReadLine());

            Console.WriteLine($"{firstNumbers:D4} {secondNumbers:D4} {thirdNumbers:D4} {fourthNumbers:D4}");
        }
    }
}
