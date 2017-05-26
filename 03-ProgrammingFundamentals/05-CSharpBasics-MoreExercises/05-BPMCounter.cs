using System;

namespace _05_BPMCounter
{
    class Program
    {
        static void Main(string[] args)
        {
            int bpm = int.Parse(Console.ReadLine());
            int numberOfBeats = int.Parse(Console.ReadLine());

            double bars = Math.Round(numberOfBeats / 4d, 1);
            int totalTime = (int)Math.Floor((numberOfBeats / (double)bpm) * 60);

            int minutes = totalTime / 60;
            int seconds = totalTime % 60;

            Console.WriteLine($"{bars} bars - {minutes}m {seconds}s");
        }
    }
}
