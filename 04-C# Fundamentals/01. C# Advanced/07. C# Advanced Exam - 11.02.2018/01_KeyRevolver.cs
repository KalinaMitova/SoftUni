namespace _01_KeyRevolver
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        static void Main()
        {
            int bulletPrice = int.Parse(Console.ReadLine());
            int gunBarrelSize = int.Parse(Console.ReadLine());

            int[] bulletsArr = Console.ReadLine()
                .Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int[] locksArr = Console.ReadLine()
                .Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int intelligence = int.Parse(Console.ReadLine());

            Queue<int> bullets = new Queue<int>(bulletsArr.Reverse());
            Queue<int> locks = new Queue<int>(locksArr);

            int earnedMoney = 0;
            int barrel = gunBarrelSize;

            while (bullets.Count > 0 && locks.Count > 0)
            {
                int bullet = bullets.Dequeue();
                int _lock = locks.Peek();

                if (bullet <= _lock)
                {
                    Console.WriteLine("Bang!");
                    locks.Dequeue();
                }
                else
                {
                    Console.WriteLine("Ping!");
                }

                earnedMoney += bulletPrice;                
                barrel--;
                if (barrel == 0)
                {
                    if(bullets.Count != 0)
                    {
                        Console.WriteLine("Reloading!");
                    }
                    if(bullets.Count >= gunBarrelSize)
                    {
                        barrel = gunBarrelSize;
                    }
                    else
                    {
                        barrel = bullets.Count;
                    }
                }
            }

            if (locks.Count == 0)
            {
                Console.WriteLine($"{bullets.Count} bullets left. Earned ${intelligence - earnedMoney}");
            }
            else if (bullets.Count == 0)
            {
                Console.WriteLine($"Couldn't get through. Locks left: {locks.Count}");
            }            
        }
    }
}
