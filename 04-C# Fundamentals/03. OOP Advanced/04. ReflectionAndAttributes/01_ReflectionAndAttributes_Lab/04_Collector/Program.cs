using System;

namespace _04_Collector
{
    public class Program
    {
        public static void Main()
        {
            Spy spy = new Spy();

            string info = spy.CollectGettersAndSetters("Hacker");

            Console.WriteLine(info);
        }
    }
}
