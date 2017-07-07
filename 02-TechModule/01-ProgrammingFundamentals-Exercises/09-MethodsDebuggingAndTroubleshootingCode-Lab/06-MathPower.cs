using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06_MathPower
{
    class Program
    {
        static void Main(string[] args)
        {
            double number = double.Parse(Console.ReadLine());
            double power = double.Parse(Console.ReadLine());

            double raisedToPower = RaiseToPower(number, power);
            Console.WriteLine(raisedToPower);
        }

        static double RaiseToPower(double number, double power)
        {
            return Math.Pow(number, power);
        }
    }
}
