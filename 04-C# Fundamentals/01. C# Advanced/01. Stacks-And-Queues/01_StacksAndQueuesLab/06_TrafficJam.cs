
namespace _06_TrafficJam
{
    using System;
    using System.Collections.Generic;

    public class TrafficJam
    {
        public static void Main()
        {
            Queue<string> trafficCars = new Queue<string>();
            int passedCars = 0;

            int n = int.Parse(Console.ReadLine());

            string input;
            while ((input = Console.ReadLine()) != "end")
            {
                if(input != "green")
                {
                    trafficCars.Enqueue(input);
                }
                else
                {
                    int counter = n;
                    while (counter > 0 && trafficCars.Count > 0)
                    {
                        Console.WriteLine("{0} passed!", trafficCars.Dequeue());
                        counter--;
                        passedCars++;
                    }
                }
            }

            Console.WriteLine("{0} cars passed the crossroads.", passedCars);
        }
    }
}
