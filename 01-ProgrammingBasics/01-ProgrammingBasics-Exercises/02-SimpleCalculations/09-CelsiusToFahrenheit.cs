using System;

namespace _09.__CelsiusТоFahrenheit
{
    class Program
    {
        static void Main(string[] args)
        {
            var celsius = double.Parse(Console.ReadLine());
            var fahrenheit = Math.Round(celsius * 1.8 + 32, 2);

            Console.WriteLine(fahrenheit);
        }
    }
}