using System;

namespace _02_PoopPipes
{
    class Program
    {
        static void Main(string[] args)
        {
            var v = int.Parse(Console.ReadLine());
            double p1 = double.Parse(Console.ReadLine());
            double p2 = double.Parse(Console.ReadLine());
            double h = double.Parse(Console.ReadLine());
            
            double totalFlow = h * (p1 + p2);
            
            if(totalFlow <= v)
            {
                double totalWater = Math.Floor(totalFlow / v * 100);
                double pipe1 = Math.Floor(h * p1 / totalFlow * 100);
                double pipe2 = Math.Floor(h * p2 / totalFlow * 100);
                Console.WriteLine("The pool is {0}% full. Pipe 1: {1}%. Pipe 2: {2}%.", totalWater, pipe1, pipe2);
            }
            else
            {
                Console.WriteLine("For {0} hours the pool overflows with {1} liters.", h, totalFlow - v);
            }
        }
    }
}
