using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_EmailMe
{
    class Program
    {
        static void Main(string[] args)
        {
            var email = Console.ReadLine();
            string[] leftRight = email.Split('@');

            var leftSum = leftRight[0].Sum(c => c);
            var rightSum = leftRight[1].Sum(c => c);

            var substract = leftSum - rightSum;

            if (substract >= 0)
            {
                Console.WriteLine("Call her!");
            }
            else
            {
                Console.WriteLine("She is not the one.");
            }
        }
    }
}
