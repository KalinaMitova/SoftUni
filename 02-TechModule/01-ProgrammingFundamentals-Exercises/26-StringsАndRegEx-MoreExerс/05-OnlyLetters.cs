using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _04_MorseCodeUpgraded
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = Console.ReadLine();

            var reg = new Regex(@"\d+(?=(?<letter>[A-z]))");

            var newPath = reg.Replace(path, m => m.Groups["letter"].Value);

            Console.WriteLine(newPath);
        }
    }
}
