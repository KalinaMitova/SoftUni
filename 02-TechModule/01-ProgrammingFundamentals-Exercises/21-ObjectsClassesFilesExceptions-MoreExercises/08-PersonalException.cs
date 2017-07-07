using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08_PersonalException
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                var num = int.Parse(Console.ReadLine());

                try
                {
                    if (num < 0)
                    {
                        throw new LowerNumberException("My first exception is awesome!!!");                        
                    }
                    Console.WriteLine(num);
                }
                catch (LowerNumberException)
                {
                    return;
                }                
            }
        }
    }

    public class LowerNumberException : Exception
    {
        public LowerNumberException(string message)
            : base(message)
        {
            Console.WriteLine(message);
        }        
    }
}
