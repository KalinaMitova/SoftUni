using System;

namespace _01_Distance
{
    class Program
    {
        static void Main(string[] args)
        {
            int speed = int.Parse(Console.ReadLine()); // 60
            int firstTime = int.Parse(Console.ReadLine()); // 2 часа
            int secondTime = int.Parse(Console.ReadLine()); 
            int thirdTime = int.Parse(Console.ReadLine());

            double currentSpeed = speed;
            double distance = currentSpeed * (firstTime / 60.0);

            currentSpeed += currentSpeed * 0.1;
            distance += currentSpeed * (secondTime / 60.0);
            currentSpeed -= currentSpeed * 0.05;
            distance += currentSpeed * (thirdTime / 60.0);

            Console.WriteLine("{0:F2}", distance);
        }
    }
}
