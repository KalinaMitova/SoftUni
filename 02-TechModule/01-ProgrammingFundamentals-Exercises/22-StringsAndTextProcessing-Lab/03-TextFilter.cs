using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_TextFilter
{
    class Program
    {
        static void Main(string[] args)
        {
            var banList = Console.ReadLine().Split(", ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

            var text = Console.ReadLine();

            foreach (var banWord in banList)
            {
                var asterix = new string('*', banWord.Length);
                text = text.Replace(banWord, asterix);
            }

            Console.WriteLine(text);
        }
    }
}
