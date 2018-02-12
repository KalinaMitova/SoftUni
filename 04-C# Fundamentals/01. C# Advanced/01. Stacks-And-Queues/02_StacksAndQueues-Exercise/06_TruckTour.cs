namespace _06_TruckTour
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class TruckTour
    {
        public static void Main()
        {
            Queue<int[]> pumps = new Queue<int[]>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                int[] pump = Console.ReadLine().Split().Select(int.Parse).ToArray();
                pumps.Enqueue(pump);
            }

            for (int startPump = 0; startPump < n - 1; startPump++)
            {
                int fuel = 0;
                bool isSoulution = true;

                for (int passedPumps = 0; passedPumps < n; passedPumps++)
                {
                    int[] currentPump = pumps.Dequeue();

                    int pumpFuel = currentPump[0];
                    int distanceToNextPump = currentPump[1];

                    pumps.Enqueue(currentPump);

                    fuel += pumpFuel - distanceToNextPump;

                    if (fuel < 0)
                    {
                        startPump += passedPumps;
                        isSoulution = false;
                        break;
                    }
                }

                if (isSoulution)
                {
                    Console.WriteLine(startPump);
                    Environment.Exit(0);
                }
            }
        }
    }
}
