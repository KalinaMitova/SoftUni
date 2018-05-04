using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_Froggy
{
    public class Program
    {
        public static void Main()
        {
            List<int> stones = Console.ReadLine()
                .Split(", ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            Lake<int> lake = new Lake<int>(stones);

            Console.WriteLine(string.Join(", ", lake));
        }
    }
}
