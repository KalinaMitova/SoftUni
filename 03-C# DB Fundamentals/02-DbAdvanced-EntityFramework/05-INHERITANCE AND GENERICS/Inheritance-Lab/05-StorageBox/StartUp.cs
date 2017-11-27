using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05_StorageBox
{
    class StartUp
    {
        public static void Main()
        {
            var box = new Box<int>();
                        
            for (int i = 0; i < 20; i++)
            {
                box.Add(i);
            }

            Console.WriteLine(box);
        }
    }
}
