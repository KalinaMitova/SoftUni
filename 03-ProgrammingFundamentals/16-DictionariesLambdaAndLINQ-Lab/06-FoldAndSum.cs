using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06_FoldAndSum
{
    class Program
    {
        static void Main(string[] args)
        {
            var allNumbers =
                Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int k = allNumbers.Length / 4;

            var leftNumbers = allNumbers.Take(k).Reverse().ToArray();
            var rightNumbers = allNumbers.Reverse().Take(k).ToArray();
            var topNumbers = leftNumbers.Concat(rightNumbers);
            var baseNumbers = allNumbers.Skip(k).Take(k * 2);
            var sumTopAndBaseNumbers = topNumbers.Zip(baseNumbers, (a, b) => a + b);

            Console.WriteLine(String.Join(" ", sumTopAndBaseNumbers));
        }
    }
}
