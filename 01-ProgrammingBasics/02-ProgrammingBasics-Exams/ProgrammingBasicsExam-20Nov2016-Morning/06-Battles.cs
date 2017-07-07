using System;

namespace _06_Battles
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstPlayerPokemons = int.Parse(Console.ReadLine());
            int secondPlayerPokemons = int.Parse(Console.ReadLine());
            int fights = 0;
            int battles = int.Parse(Console.ReadLine());

            for (int firstPlayer = 1; firstPlayer <= firstPlayerPokemons; firstPlayer++)
            {
                for (int secondPlayer = 1; secondPlayer <= secondPlayerPokemons; secondPlayer++)
                {
                    if (battles == fights)
                    {
                        Console.WriteLine();
                        return;
                    }
                    Console.Write("({0} <-> {1}) ", firstPlayer, secondPlayer);
                    fights++;
                }
            }
        }
    }
}
