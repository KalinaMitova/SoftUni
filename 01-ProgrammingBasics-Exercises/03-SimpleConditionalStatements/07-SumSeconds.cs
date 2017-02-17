using System;

namespace _07___SumSeconds
{
    class Program
    {
        static void Main(string[] args)
        {
            var a = int.Parse(Console.ReadLine());
            var b = int.Parse(Console.ReadLine());
            var c = int.Parse(Console.ReadLine());

            var time = a + b + c;
            var minutes = time / 60;
            var seconds = time % 60;

            string timeToString = minutes + ":";

            if (seconds < 10)
            {
                timeToString += "0" + seconds;
            }
            else
            {
                timeToString += seconds;
            }

            Console.WriteLine(timeToString);
        }
    }
}