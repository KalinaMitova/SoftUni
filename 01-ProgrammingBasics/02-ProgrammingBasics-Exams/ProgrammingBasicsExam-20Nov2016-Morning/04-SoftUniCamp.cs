using System;

namespace _04_SoftUniCamp
{
    class Program
    {
        static void Main(string[] args)
        {
            int groups = int.Parse(Console.ReadLine());

            int transportWithCar = 0;
            int transportWithBus = 0;
            int transportWithSmallBus = 0;
            int transportWithBigBus = 0;
            int transportWithTrain = 0;
            int totalPeople = 0;

            for (int i = 0; i < groups; i++)
            {
                int peoplesInGroup = int.Parse(Console.ReadLine());

                if(peoplesInGroup > 0 && peoplesInGroup <= 5)
                {
                    transportWithCar += peoplesInGroup;
                }
                else if(peoplesInGroup > 5 && peoplesInGroup <= 12)
                {
                    transportWithBus += peoplesInGroup;
                }
                else if(peoplesInGroup > 12 && peoplesInGroup <= 25)
                {
                    transportWithSmallBus += peoplesInGroup;
                }
                else if(peoplesInGroup > 25 && peoplesInGroup <= 40)
                {
                    transportWithBigBus += peoplesInGroup;
                }
                else
                {
                    transportWithTrain += peoplesInGroup;
                }

                totalPeople += peoplesInGroup;
            }

            Console.WriteLine("{0:F2}%", Math.Round(transportWithCar / (double)totalPeople * 100, 2));
            Console.WriteLine("{0:F2}%", Math.Round(transportWithBus / (double)totalPeople * 100, 2));
            Console.WriteLine("{0:F2}%", Math.Round(transportWithSmallBus / (double)totalPeople * 100, 2));
            Console.WriteLine("{0:F2}%", Math.Round(transportWithBigBus / (double)totalPeople * 100, 2));
            Console.WriteLine("{0:F2}%", Math.Round(transportWithTrain / (double)totalPeople * 100, 2));
        }
    }
}
