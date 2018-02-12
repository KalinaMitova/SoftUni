namespace _02_KnightsOfHonor
{
    using System;
    using System.Linq;

    public class KnightsOfHonor
    {
        public static void Main()
        {
            Action<string> print = name => Console.WriteLine("Sir " + name);

            Console.ReadLine()
                .Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
                .ToList().ForEach(print);
        }
    }
}
