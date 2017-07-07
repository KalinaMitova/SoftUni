using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace _01_SinoTheWalker
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTime leaveTime = DateTime.ParseExact(
                Console.ReadLine(), 
                "HH:mm:ss", 
                CultureInfo.InvariantCulture);

            long steps = long.Parse(Console.ReadLine());
            long secondsPerStep = long.Parse(Console.ReadLine());
                        
            var totalSeconds = leaveTime.Second + 
                (leaveTime.Minute * 60) + 
                (leaveTime.Hour * 60 * 60) +
                (steps * secondsPerStep);

            var seconds = totalSeconds % 60;
            var minutes = (totalSeconds / 60) % 60;
            var hours = (totalSeconds / 60 / 60) % 24;

            Console.WriteLine($"Time Arrival: {hours:D2}:{minutes:D2}:{seconds:D2}");
        }
    }
}
