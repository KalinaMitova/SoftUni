using System;

namespace _02_HighQualityMistakes
{
    public class Program
    {
        public static void Main()
        {
            Spy spy = new Spy();

            string info = spy.AnalyzeAcessModifiers("System.Text.StringBuilder");

            Console.WriteLine(info);
        }
    }
}
