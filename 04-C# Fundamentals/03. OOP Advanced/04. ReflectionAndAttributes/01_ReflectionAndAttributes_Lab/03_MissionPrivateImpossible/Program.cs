using System;

namespace _03_MissionPrivateImpossible
{
    public class Program
    {
        public static void Main()
        {
            Spy spy = new Spy();

            string info = spy.RevealPrivateMethods("System.Text.StringBuilder");

            Console.WriteLine(info);
        }
    }
}
