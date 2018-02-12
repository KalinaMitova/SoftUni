namespace _01_ActionPoint
{
    using System;
    using System.Linq;

    public class ActionPoint
    {
        public static void Main()
        {
            Action<string> print = str => Console.WriteLine(str);

            Console.ReadLine().Split().ToList().ForEach(print);
        }
    }
}
