using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_SortTimes
{
    class Program
    {
        static void Main(string[] args)
        {
            var times = Console.ReadLine().Split().Select(DateTime.Parse).ToList();

            times.Sort();

            string[] timesToString = times.Select(t => string.Format("{0:HH:mm}", t)).ToArray();

            Console.WriteLine(string.Join(", ", timesToString));            
        }
    }
}
