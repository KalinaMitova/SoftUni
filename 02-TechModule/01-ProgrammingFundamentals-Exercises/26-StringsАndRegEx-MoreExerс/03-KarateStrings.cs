using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_KarateStrings
{
    class Program
    {
        static void Main(string[] args)
        {
            //abv>1>1>2>2asdasd

            var path = Console.ReadLine();
            var strength = 0;

            for (int i = 0; i < path.Length - 1; i++)
            {
                if (path[i] == '>')
                {
                    strength += int.Parse(path[i + 1].ToString());
                    
                    while (strength > 0 && i + 1 < path.Length && path[i + 1] != '>')
                    {
                        path = path.Remove(i + 1, 1);
                        strength--;
                    }
                }
            }

            Console.WriteLine(path);
        }
    }
}
