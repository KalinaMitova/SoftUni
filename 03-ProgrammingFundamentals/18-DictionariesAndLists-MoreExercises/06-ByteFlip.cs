using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06_ByteFlip
{
    class Program
    {
        static void Main(string[] args)
        {
            // A 12 B 46 C 56 DDD 46 EEE F6 FFF 36 56 46

            var numbers = Console.ReadLine().Split().ToList();

            var filteredNumbers = numbers.Where(el => el.Length == 2).ToList();
            var reversed = filteredNumbers
                .Select(el => new string(el.ToCharArray().Reverse().ToArray()))
                .Reverse()
                .ToList();

            var hexToChar = reversed.Select(el => (char)Convert.ToInt32(el, 16)).ToList();
                        
            Console.WriteLine(string.Join("", hexToChar));            
        }
    }
}
