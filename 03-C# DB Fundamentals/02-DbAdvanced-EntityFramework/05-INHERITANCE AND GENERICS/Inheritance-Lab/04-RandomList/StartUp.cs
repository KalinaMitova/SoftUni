using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_RandomList
{
    class StartUp
    {
        static void Main(string[] args)
        {
            RandomList rndList = new RandomList();

            for (int i = 0; i < 10; i++)
            {
                rndList.Add("Str - " + i);
            }

            Console.WriteLine(rndList.RandomString());

            Console.WriteLine(string.Join(", ", rndList));
        }
    }
}
