namespace _14_BoatSimulator
{
    using System;

    static class Program
    {
        static void Main()
        {
            char firstBoat = char.Parse(Console.ReadLine());
            char secondBoat = char.Parse(Console.ReadLine());
            int n = int.Parse(Console.ReadLine());

            int firstBoatMoves = 0;
            int secondBoatMoves = 0;

            for (int i = 1; i <= n; i++)
            {
                string word = Console.ReadLine();

                if (word == "UPGRADE")
                {
                    firstBoat += (char)3;
                    secondBoat += (char)3;
                }
                else
                {
                    if (i % 2 != 0)
                    {
                        firstBoatMoves += word.Length;
                        if (firstBoatMoves >= 50)
                        {
                            Console.WriteLine(firstBoat);
                            return;
                        }
                    }
                    else
                    {
                        secondBoatMoves += word.Length;
                        if (secondBoatMoves >= 50)
                        {
                            Console.WriteLine(secondBoat);
                            return;
                        }
                    }
                }
            }

            if (firstBoatMoves > secondBoatMoves)
            {
                Console.WriteLine(firstBoat);
            }
            else
            {
                Console.WriteLine(secondBoat);
            }
        }
    }
}