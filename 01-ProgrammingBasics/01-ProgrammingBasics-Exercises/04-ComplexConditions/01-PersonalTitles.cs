using System;

namespace _01_PersonalTitles
{
    class Program
    {
        static void Main(string[] args)
        {
            double age = double.Parse(Console.ReadLine());
            string gender = Console.ReadLine().ToLower();

            if (age >= 16)
            {
                if (gender == "m") Console.WriteLine("Mr.");
                else Console.WriteLine("Ms.");
            }
            else
            {
                if (gender == "m") Console.WriteLine("Master");
                else Console.WriteLine("Miss");
            }
        }
    }
}
