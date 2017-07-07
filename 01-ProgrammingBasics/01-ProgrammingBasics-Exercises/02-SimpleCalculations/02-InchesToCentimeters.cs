using System;

namespace _02.InchesToCentimeters
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("inches = ");
            var inch = double.Parse(Console.ReadLine());
            var centimeters = inch * 2.54;
            Console.WriteLine("centimeters = " + centimeters);
        }
    }
}