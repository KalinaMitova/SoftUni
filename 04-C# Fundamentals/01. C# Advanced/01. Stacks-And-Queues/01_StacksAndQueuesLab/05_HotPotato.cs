namespace _05_HotPotato
{
    using System;
    using System.Collections.Generic;

    public class HotPotato
    {
        public static void Main()
        {
            string[] input = Console.ReadLine().Split(' ');
            int n = int.Parse(Console.ReadLine());

            Queue<string> players = new Queue<string>(input);

            int counter = 1;
            while (players.Count > 1)
            {
                if (counter % n == 0)
                {
                    Console.WriteLine("Removed {0}", players.Dequeue());
                }
                else
                {
                    string firstPlayer = players.Dequeue();
                    players.Enqueue(firstPlayer);
                }
                counter++;
            }

            Console.WriteLine("Last is {0}", players.Dequeue());
        }
    }
}
